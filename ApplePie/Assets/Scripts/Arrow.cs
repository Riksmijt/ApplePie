using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bokser" || collision.transform.tag == "Archer" || collision.transform.tag == "Tank")
        {
            PlayerMovement.playerHealth -= 1;
        }
        if(collision.transform.tag == "Bokser" || collision.transform.tag == "Archer" || collision.transform.tag == "Tank")
        {
            PlayerMovement.playerHealth -= 2;
        }
    }
}
