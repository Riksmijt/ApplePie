using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private bool hasLanded;
    private bool applePickedUp = false;
    private PlayerMovement currentPlayer;

    public bool HasLanded { get => hasLanded; set => hasLanded = value; }
    public bool ApplePickedUp { get => applePickedUp; set => applePickedUp = value; }

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
            ApplePickedUp = false;
        }
        if (collision.gameObject.tag == "BasketRed" && !HasLanded) 
        {
            currentPlayer.DropApple();
            currentPlayer.SetHasApple(false);
            this.transform.SetParent(null);
            this.transform.position = new Vector3(0, 6, -4.5f);
            this.GetComponent<Rigidbody>().isKinematic = false;
            HasLanded = true;
            currentPlayer = null;
            Manager.redScore += 1;
        }
        if (collision.gameObject.tag == "BasketBlue" && !HasLanded)
        {
            currentPlayer.DropApple();
            currentPlayer.SetHasApple(false);
            this.transform.SetParent(null);
            this.transform.position = new Vector3(0, 6, -4.5f);
            this.GetComponent<Rigidbody>().isKinematic = false;
            HasLanded = true;
            currentPlayer = null;
            Manager.blueScore += 1;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ground") 
        {
            ApplePickedUp = true;
        }
    }
    public void SetPlayerMovement(PlayerMovement player)
    {
        currentPlayer = player;
    }
}
