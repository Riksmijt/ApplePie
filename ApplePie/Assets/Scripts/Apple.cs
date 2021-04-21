using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public bool hasLanded;
    private PlayerMovement currentPlayer;
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
            currentPlayer.SetHasApple(false);
            currentPlayer = null;
        }
        if(collision.gameObject.tag == "BasketRed" && !hasLanded) 
        {
            currentPlayer.DropApple();
            currentPlayer.SetHasApple(false);
            this.transform.SetParent(null);
            this.transform.position = new Vector3(0, 6, -4.5f);
            this.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("Hits basket red");
            hasLanded = true;
            currentPlayer = null;
            Manager.redScore += 1;
        }
        if (collision.gameObject.tag == "BasketBlue" && !hasLanded)
        {
            currentPlayer.DropApple();
            currentPlayer.SetHasApple(false);
            this.transform.SetParent(null);
            this.transform.position = new Vector3(0, 6, -4.5f);
            this.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("Hits basket red");
            hasLanded = true;
            currentPlayer = null;
            Manager.blueScore += 1;
        }
    }
    public void SetPlayerMovement(PlayerMovement player)
    {
        currentPlayer = player;
    }
}
