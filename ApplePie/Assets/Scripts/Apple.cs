using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public bool hasLanded;
    public bool applePickedUp = false;
    private PlayerMovement currentPlayer;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Yard") 
        {
            this.transform.position = new Vector3(0, 7, 0);
            currentPlayer.SetHasApple(false);
            currentPlayer = null;
        }
        if (collision.gameObject.tag == "Ground")
        {
            applePickedUp = false;
        }
        if (collision.gameObject.tag == "BasketRed" && !hasLanded) 
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
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground") 
        {
            applePickedUp = true;
        }
    }
    public void SetPlayerMovement(PlayerMovement player)
    {
        currentPlayer = player;
    }
}
