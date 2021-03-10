﻿using System.Collections;
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
    private bool isPunching;
    private Rigidbody selfRigidbody;

    private GameObject playerRotation;

    private Vector2 movementInput;
    private Vector2 jumpInput;

[SerializeField] private float speed = 5f;
[SerializeField] private float health = 2f;

    void Start()
    {
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

        Debug.Log(health);
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);

      

    }
    public void OnMoving(InputAction.CallbackContext ctx)
    {
        if (canMove)
        {
            movementInput = ctx.ReadValue<Vector2>();
        }
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
    
            arm.SetActive(true);
        isPunching = true;
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
            other.gameObject.GetComponent<PlayerMovement>().health -= 1f;
            if(other.gameObject.GetComponent<PlayerMovement>().health < 0f)
            {
                Destroy(other.gameObject);
            }
            Debug.Log(other.gameObject.GetComponent<PlayerMovement>().health);
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
