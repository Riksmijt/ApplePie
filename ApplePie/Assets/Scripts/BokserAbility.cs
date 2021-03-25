using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BokserAb1 : MonoBehaviour
{
    [SerializeField] private float force;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bokser")
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(Vector3.back * force);
            PlayerMovement.playerHealth += 1;
        }
    }
}
