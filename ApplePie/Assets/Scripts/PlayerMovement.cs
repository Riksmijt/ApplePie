using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public float speed = 5;
    public GameObject arm;
    public int forceConst = 20;
    public bool isGrounded;
    private bool canJump;
    public bool canMove;
    private Rigidbody selfRigidbody;

    private Vector2 movementInput;
    private Vector2 jumpInput;

[SerializeField] private float speed = 5f;

    void Start()
    {
        arm.SetActive(false);
        selfRigidbody = GetComponent<Rigidbody>();
    }
    public void OnPlayerJoined(InputAction.CallbackContext context)
    {
        Debug.Log("works");
    }
  
    void CheckClass()
    {

    }
    void Update()
    {

        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);

        if (canJump && isGrounded)
        {
            
            canJump = false;
            selfRigidbody.AddForce(0, forceConst, 0,ForceMode.Impulse);
        }

    }
    public void OnMoving(InputAction.CallbackContext ctx)
    {
        if (canMove)
        {
            movementInput = ctx.ReadValue<Vector2>();
        }
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (Gamepad.current.buttonSouth.isPressed)
        {
            Debug.Log("Pressedsouth");
            canJump = true;
        }
    }
    public void onPunching(InputAction.CallbackContext ctx)
    {
        if (Gamepad.current.buttonWest.isPressed)
        {
            arm.SetActive(true);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            canMove = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            canMove = false;
        }
    }




}
