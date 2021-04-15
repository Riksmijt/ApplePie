using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public bool hasLanded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Yard") 
        {
            this.transform.position = new Vector3(0, 7, 0);
        }
        if(collision.gameObject.tag == "BasketRed" && !hasLanded) 
        {
            this.transform.SetParent(null);
            this.transform.position = new Vector3(0, 6, -4.5f);
            this.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("Hits basket red");
            hasLanded = true;
            Manager.redScore += 1;
        }
        if (collision.gameObject.tag == "BasketBlue" && !hasLanded)
        {
            this.transform.SetParent(null);
            this.transform.position = new Vector3(0, 6, -4.5f);
            this.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("Hits basket red");
            hasLanded = true;
            Manager.blueScore += 1;
        }
    }
}
