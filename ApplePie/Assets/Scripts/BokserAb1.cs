using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BokserAb1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Bokser")
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(Vector3.back * 1000);
        }
    }
}
