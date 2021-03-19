using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Users;

public class Manager : MonoBehaviour
{

    private bool archerIsSpawned;
    private bool bokserIsSpawned;
    private bool tankIsSpawned;
    bool isPressed;

   // Update is called once per frame
   void Update()
   {

        if(PlayerMovement.playerHealth < 0 && PlayerMovement.isSpawned)
        {
            PlayerMovement.playerHealth = 2;
            PlayerMovement.isSpawned = false;
        }

   }
}

