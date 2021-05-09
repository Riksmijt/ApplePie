using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private int forceConst = 60;
    private float timer;
    private float saveHealth;
    public float saveSpeed;

    public bool isGrounded;
    private bool canJump;
    public bool canMove;
    private bool canAttack = true;
    private bool hasApple;

    private Rigidbody selfRigidbody;

    public int index;

    public float playerHealth;
    public static bool isSpawned;
    private GameObject appleObject;
    [SerializeField] private BokserAbilityOne abilityOne;
    [SerializeField] private BokserAbilityTwo abilityTwo;
    private MeshRenderer playerRenderer;

    [SerializeField] private GameObject arm;
    private Music musicManager;

    private Vector2 movementInput;
    private Vector2 rotateInput;

    public float speed = 5f;
    void Start()
    {
        playerRenderer = gameObject.GetComponent<MeshRenderer>();
        selfRigidbody = GetComponent<Rigidbody>();
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<Music>();
        playerHealth = 5;
        saveHealth = playerHealth;
        saveSpeed = speed;
        timer = 0;
        isSpawned = false;
        arm.SetActive(false);
    }
    IEnumerator StartAttackCoolDown()
    {
        canAttack = false;
        yield return new WaitForSeconds(1);
        canAttack = true;
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
        transform.Rotate(0, rotateInput.x * 3f, 0, Space.World);
        if (appleObject)
        {
            appleObject.transform.position = transform.position + transform.forward * 1f + transform.up * 1f;
        }
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
        Vector2 rotationCap = ctx.ReadValue<Vector2>();
        if (rotationCap.x >= 0.1)
        {
            rotateInput = new Vector2(0.1f, rotationCap.y);
        }
        else if (rotationCap.x <= -0.1)
        {
            rotateInput = new Vector2(-0.1f, rotationCap.y);
        }
        else
        {
            rotateInput = rotationCap;
        }
    }
    public void OnJump()
    {
        canJump = true;
        if (canJump && isGrounded)
        {
            selfRigidbody.AddForce(0, forceConst, 0, ForceMode.Impulse);
            musicManager.PlayClip("jump", 0.4f);
            canJump = false;
        }
    }
    public void AbilityOne(InputAction.CallbackContext ctx)
    {
        abilityOne.ActivateAbility();
    }
    public void AbbilitieTwo(InputAction.CallbackContext ctx)
    {
        abilityTwo.ActivateAbility();
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
                    hits[i].collider.GetComponent<PlayerMovement>().TakeDamage(1,false);
                    if (this.isActiveAndEnabled)
                    {
                        StartCoroutine(StartAttackCoolDown());
                    }
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
    IEnumerator ChangeColorOnDamage()
    {
        Material[] materials = playerRenderer.materials;
        Color originalColor;
        if (PlayerPicker.loadArcher)
        {
            originalColor = materials[0].color;
            materials[0].color = Color.red;
        }
        else
        {
            originalColor = materials[0].color;
            materials[0].color = Color.red;
        }
        yield return new WaitForSeconds(1);
        if (PlayerPicker.loadArcher)
        {
            materials[0].color = originalColor;
        }
        else
        {
            materials[0].color = originalColor;
        }
    }
    public void TakeDamage(float damage, bool stunHit)
    {
        playerHealth-= damage;
        musicManager.PlayClip("Damage", 0.8f);
        StartCoroutine(ChangeColorOnDamage());
        if (playerHealth <= 0) 
        {
            if (appleObject)
            {
                appleObject.transform.SetParent(null);
                appleObject.GetComponent<Rigidbody>().isKinematic = false;
                appleObject = null;
            }
            transform.position = new Vector3(2, 10, 2);
            playerHealth = saveHealth;
        }
        if (stunHit)
        {
            StartCoroutine(StunPlayer());
        }
    }
    public void OnPickingUpApple()
    {
        RaycastHit[] hits;
        hits = Physics.SphereCastAll(transform.position, 2, transform.up);
        for (int i = 0; i < hits.Length; i++)
        {
            
            if (!appleObject)
            {
                if (hits[i].transform.tag == "Apple" && !hits[i].transform.gameObject.GetComponent<Apple>().applePickedUp)
                {
                    musicManager.PlayClip("ApplePickedUp", 0.4f);
                    appleObject = hits[i].transform.gameObject;
                    SetHasApple(true);
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
