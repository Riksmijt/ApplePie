﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bokser")
        {
            PlayerMovement.playerHealth -= 1;
        }
        if (collision.transform.tag == "Bokser" && Archer.shootingAbilityOne)
        {
            PlayerMovement.playerHealth -= 2;
        }
    }
}
