using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public float speed = 5;
    public GameObject arm;
    public int forceConst = 60;
    public bool isGrounded;
    private bool canJump;
    public bool canMove;
    private bool isPunching;
    private Rigidbody selfRigidbody;
    float playerHealth;


    private GameObject Enemy;
    private GameObject playerRotation;

    private Vector2 movementInput;
    private Vector2 jumpInput;
    private Vector2 rotateInput;

[SerializeField] private float speed = 5f;
[SerializeField] private float health = 2f;

    void Start()
    {
        playerRotation = GameObject.FindGameObjectWithTag("Bokser");
        arm.SetActive(false);
        selfRigidbody = GetComponent<Rigidbody>();
    }
    IEnumerator RespawnPlayer(GameObject player)
    {
        player.SetActive(false);

        yield return new WaitForSeconds(2);

        player.transform.position = new Vector3(2, 2, 2);
        player.SetActive(true);
        
        
    }
    IEnumerator Punch(GameObject arm)
    {
        arm.SetActive(true);
        isPunching = true;
        yield return new WaitForSeconds(0.5f);

        arm.SetActive(false);
        isPunching = false;
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
        if (playerHealth < 0f)
        {
            StartCoroutine(RespawnPlayer(Enemy.gameObject));
            playerHealth = 2;
        }
        Debug.Log(health);
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
        transform.Rotate(0, rotateInput.y * 3f, 0);


    }
    public void OnMoving(InputAction.CallbackContext ctx)
    {
        if (canMove)
        {
            movementInput = ctx.ReadValue<Vector2>() * 0.7f;
        }
    }
    public void OnRotate(InputAction.CallbackContext ctx)
    {
        rotateInput = ctx.ReadValue<Vector2>();
    }
    
    public void OnJump()
    {
        canJump = true;
        if (canJump && isGrounded)
        {

            selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
            

            canJump = false;

        }
    }
    public void onPunching()
    {
        StartCoroutine(Punch(arm));
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            canMove = true;
        }
        if(other.gameObject.tag == "Bokser" && isPunching == true)
        {
            playerHealth = other.gameObject.GetComponent<PlayerMovement>().health -= 1f;
            Enemy = other.gameObject;
            
            Debug.Log(playerHealth);
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
