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
    private bool hasApple;

    private int slappingStarmina;

    private Rigidbody selfRigidbody;

    public int index;

    public float playerHealth;
    public static bool isSpawned;
    private GameObject appleObject;
    [SerializeField] private BokserAbilityOne bokserabilityOne;
    [SerializeField] private BokserAbilityTwo bokserabilityTwo;
    [SerializeField] private Archer archer;
    [SerializeField] private GameObject bokser;
    

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
        canMove = true;
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
    public void ToggleCanMove(bool movable)
    {
        canMove = movable;
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
        float deltaSpeed = (hasApple) ? -3f : 0f;
 
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * (speed + deltaSpeed) * Time.deltaTime);
        transform.Rotate(0, rotateInput.x * 4f, 0, Space.World);
        
        if (appleObject)
        {
            appleObject.transform.position = transform.position + transform.forward * 1f + transform.up * 1f;
        }
    }
    IEnumerator StunPlayer()
    {
        Debug.Log("Courentine started");
        speed = 0;
        yield return new WaitForSeconds(2);
        Debug.Log("Courentine ended");
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
    public void AbilityOne(InputAction.CallbackContext ctx)
    {
        if (bokser.activeInHierarchy)
        {
            bokserabilityOne.ActivateAbility();
        }
        else
        {
            archer.AbilityOne();
            //todo add archer ability here
        }
        
    }

    public void AbbilitieTwo(InputAction.CallbackContext ctx)
    {
        
        if (bokser.activeInHierarchy)
        {
            bokserabilityTwo.ActivateAbility();
        }
        else
        {
            archer.AbilityTwo();
            //todo add archer ability here
        }
    }
    public void OnPunching()
    {
        Debug.Log("isPunching");
        if (canAttack)
        {
            RaycastHit[] hits;
            hits = Physics.SphereCastAll(transform.position + transform.forward * 1, 1, transform.up);
            for (int i = 0; i < hits.Length; i++)
            {
                Debug.Log(hits[i].transform.name);
                if (hits[i].collider.tag == "Player" && hits[i].collider.gameObject != gameObject)
                {
                    hits[i].collider.GetComponent<PlayerMovement>().TakeDamage(1,false);
                    StartCoroutine(StartAttackCoolDown());
                    return;
                }
            }
        }
        }
    public void OnDodging()
    { 
       
    }
    public void SetHasApple(bool hasApple)
    {
        this.hasApple = hasApple;
    }
    public void TakeDamage(float damage, bool stunHit)
    {
        playerHealth-= damage;
        //musicManager.PlayClip("Damage", 0.8f);
        if (playerHealth <= 0) 
        {
            
            
            if (appleObject)
            {
                appleObject.transform.SetParent(null);
                //appleObject.transform.position = new Vector3(0, 6, -4.5f);
                appleObject.GetComponent<Rigidbody>().isKinematic = false;
                appleObject = null;

            }
            transform.position = new Vector3(2, 10, 2);
            playerHealth = saveHealth;
            //return;
        }
        if (stunHit)
        {
            Debug.Log(stunHit);
            StartCoroutine(StunPlayer());
        }
    }
    public void OnPickingUpApple()
    {
        Debug.Log("Pressed appel");
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 2, transform.up);
        for (int i = 0; i < hits.Length; i++)
        {
   
            if(!appleObject)
            {
                if (hits[i].transform.tag == "Apple")
                {
                    musicManager.PlayClip("ApplePickedUp",0.4f);
                    appleObject = hits[i].transform.gameObject;
                    SetHasApple(true);
                    //appleObject.transform.localScale = new Vector3(0.4f,0.4f,0.4f);
                    appleObject.GetComponent<Apple>().SetPlayerMovement(this);
                    appleObject.GetComponent<Rigidbody>().isKinematic = true;
                    appleObject.GetComponent<Apple>().hasLanded = false;
                    return;
                }
                
            }
        }
    }
    public void DropApple()
    {
        appleObject = null;
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
