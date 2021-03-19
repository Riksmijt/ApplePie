﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private int forceConst = 60;
    private float timer;
    private float punchCounter;

    public bool isGrounded;
    private bool canJump;
    public bool canMove;
    private bool isPunching;

    private Rigidbody selfRigidbody;

    public static float playerHealth;
    public static bool isSpawned;

    public GameObject arm;
    private GameObject Enemy;
    private GameObject playerRotation;

    private Vector2 movementInput;
    private Vector2 jumpInput;
    private Vector2 rotateInput;

[SerializeField] private float speed = 5f;
[SerializeField] private float health = 2f;

    void Start()
    {
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
        
 
        Debug.Log(playerHealth);
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
       
        Debug.Log(isPunching);

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
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            canMove = true;
        }
        if(other.gameObject.tag == "Bokser" && isPunching == true )
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
