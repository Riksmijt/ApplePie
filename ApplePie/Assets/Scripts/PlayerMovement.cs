using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public float speed = 5;
    public int forceConst = 20;

    private bool canJump;
    private Rigidbody selfRigidbody;

    private Vector2 movementInput;
    private Vector2 jumpInput;

[SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
    }
    public void OnPlayerJoined(InputAction.CallbackContext context)
    {
        Debug.Log("works");
    }
    // Update is called once per frame
    void CheckClass()
    {

    }
    void Update()
    {

        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);

        if (canJump)
        {
            canJump = false;
            selfRigidbody.AddForce(0, forceConst, 0,ForceMode.Impulse);
        }

    }
    public void OnMoving(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (Gamepad.current.buttonSouth.isPressed)
        {
            Debug.Log("Pressedsouth");
            canJump = true;
        }
    }

   


}
