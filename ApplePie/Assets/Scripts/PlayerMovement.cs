using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private int forceConst = 60;
    private float timer;
    private float punchCounter;

    private bool isGrounded;
    private bool canJump;
    private bool canMove;
    private bool isPunching;
    private bool canDodge;
   

    private Rigidbody selfRigidbody;

    public static float playerHealth;
    public static bool isSpawned;
    private GameObject appleObject;

    [SerializeField] private GameObject arm;
    private GameObject Enemy;
    private GameObject playerRotation;

    private Music musicManager;

    private Vector2 movementInput;
    private Vector2 jumpInput;
    private Vector2 rotateInput;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float health = 2f;

    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<Music>();
        playerHealth = 5;
        punchCounter = 0;
        timer = 0;
        isSpawned = false;
        playerRotation = GameObject.FindGameObjectWithTag("Bokser");
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
        if (playerHealth <= 0f)
        {

            Enemy.transform.position = new Vector3(2, 2, 2);
            timer += 1 * Time.deltaTime;
           // StartCoroutine(RespawnPlayer(Enemy.gameObject));
        }
       if(timer >= 3f)
        {
            timer = 0;
            playerHealth = 5;
        }
        if (isPunching)
        {
            punchCounter += 1 * Time.deltaTime;
            if (punchCounter >= 0.1)
            {
                arm.SetActive(false);
                isPunching = false;
            }
        }
        if(canDodge == true)
        {
            float a = rotateInput.y + 1;
            selfRigidbody.AddForce(Vector3.back * a * 10000);
            canDodge = false;
        }
        

        Debug.Log(playerHealth);
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);


    }
    public void FixedUpdate()
    {
        transform.Rotate(0, rotateInput.y * 6f, 0, Space.World);
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
            musicManager.PlayClip("jump");

            canJump = false;

        }
    }
    public void OnPunching()
    {
        if (!isPunching)
        {
            arm.SetActive(true);
            isPunching = true;
            punchCounter = 0;
        }
    }
    public void OnDodging()
    {
        canDodge = true;
    }

    public void OnPickingUpApple()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 5, transform.up);
        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].transform.name);
            if (appleObject)
            {
                if (hits[i].transform.tag == "BasketBlue")
                {
                    appleObject.transform.SetParent(null);
                    appleObject.transform.position = new Vector3(0, 6, -4.5f);
                    appleObject.GetComponent<Rigidbody>().isKinematic = false;
                    appleObject = null;
                    return;
                }
            }
            else
            {
                if (hits[i].transform.tag == "Apple")
                {
                    appleObject = hits[i].transform.gameObject;
                    appleObject.transform.SetParent(transform);
                    appleObject.transform.position = transform.position + transform.forward * 1;
                    appleObject.GetComponent<Rigidbody>().isKinematic = true;
                    return;
                }
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            canMove = true;
        }
        if (other.gameObject.tag == "Bokser" && isPunching == true)
        {
            Enemy = other.gameObject;
            if (playerHealth > 0)
            {
                //playerHealth = other.gameObject.GetComponent<PlayerMovement>().health -= 1f;
                playerHealth -= 1;

            }
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
