using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private int forceConst = 60;
    private float timer;
    private float punchCounter;
    private float saveHealth;
    public float saveSpeed;

    public bool isGrounded;
    private bool canJump;
    public bool canMove;
    private bool canAttack = true;

    private int slappingStarmina;

    private Rigidbody selfRigidbody;

    public int index;

    public float playerHealth;
    public static bool isSpawned;
    private GameObject appleObject;

    [SerializeField] private GameObject arm;
    private GameObject Enemy;
    private GameObject playerRotation;

    private Music musicManager;

    private Vector2 movementInput;
    private Vector2 jumpInput;
    private Vector2 rotateInput;
    private Arrow arrow;

    public float speed = 5f;
    [SerializeField] private float health = 2f;

    private GameObject manager;

    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody>();
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<Music>();
        playerHealth = 5;
        punchCounter = 2;
        saveHealth = playerHealth;
        saveSpeed = speed;
        timer = 0;
        isSpawned = false;
        playerRotation = GameObject.FindGameObjectWithTag("Bokser");
        arm.SetActive(false);
        manager = GameObject.Find("PlayerManager");
    }
    IEnumerator StartAttackCoolDown()
    {
        canAttack = false;
        yield return new WaitForSeconds(1);
        canAttack = true;
    }
    public void OnPlayerJoined(InputAction.CallbackContext context)
    {
        Debug.Log("works");
    }

    void Update()
    {
        if (playerHealth <= 0f)
        {
            timer += 1 * Time.deltaTime;
        }
        if (timer >= 3f)
        {
            timer = 0;
            playerHealth = 5;
        }

        Debug.Log(playerHealth);
        Debug.Log(saveSpeed);
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
        transform.Rotate(0, rotateInput.x * 1f, 0, Space.World);
        
    }
    IEnumerator StunPlayer()
    {
        speed = 0;
        yield return new WaitForSeconds(2);
        speed = saveSpeed;
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
            musicManager.PlayClip("jump",0.4f);
            canJump = false;
        }
    }

    public void OnPunching()
    {

        if (canAttack)
        { 
            RaycastHit[] hits;
            hits = Physics.SphereCastAll(transform.position + transform.forward * 1, 1, transform.up);
            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log(hits[i].transform.name);
                if (hits[i].collider.tag == "Player" && hits[i].collider.gameObject != gameObject)
                {
                    musicManager.PlayClip("Hitting", 0.3f);
                    hits[i].collider.GetComponent<PlayerMovement>().TakeDamage(1);
                    StartCoroutine(StartAttackCoolDown());
                    return;
                }
            }
        }
        }
    public void OnDodging()
    { 
       
    }

    public void TakeDamage(float damage)
    {
        playerHealth-= damage;
        if(playerHealth <= 0) 
        {
            transform.position = new Vector3(2, 10, 2);
            playerHealth = saveHealth;
            if (appleObject)
            {
                appleObject.transform.SetParent(null);
                appleObject.transform.position = new Vector3(0, 6, -4.5f);
                appleObject.GetComponent<Rigidbody>().isKinematic = false;
                appleObject = null;
            }
            
        }
    }
    public void OnPickingUpApple()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 7, transform.up);
        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].transform.name);
            if (appleObject)
            {
                if (hits[i].transform.tag == "BasketBlue")
                {
                    Manager.blueScore += 0.5f;
                    appleObject.transform.SetParent(null);
                    appleObject.transform.position = new Vector3(0, 6, -4.5f);
                    appleObject.GetComponent<Rigidbody>().isKinematic = false;
                    appleObject = null;
                    return;
                }
                if (hits[i].transform.tag == "BasketRed")
                {
                    Manager.redScore += 0.5f;
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
                    musicManager.PlayClip("ApplePickedUp",0.4f);
                    appleObject = hits[i].transform.gameObject;
                    appleObject.transform.SetParent(transform);
                    appleObject.transform.position = transform.position + transform.forward * 1.5f;
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
        if(other.gameObject.tag == "Arrow") 
        {
           // other.gameObject.GetComponent<Arrow>().stunArrowHit = true;
            if(other.gameObject.GetComponent<Arrow>().stunArrowHit == true) 
            {
                StartCoroutine(StunPlayer());
                other.gameObject.GetComponent<Arrow>().stunArrowHit = false;
            }
        }
        /*if (other.gameObject.tag == "Player" && isPunching == true && other.gameObject != arm)
        {
            Enemy = other.gameObject;
            musicManager.PlayClip("Damage");
            if (playerHealth > 0)
            {
                playerHealth -= 1;
                if(playerHealth <= 0)
                {
                    
                }
            }
        }*/
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
