using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BokserAb1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bokser")
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(Vector3.back * 100000);
            PlayerMovement.playerHealth += 1;
        }
    }
}
