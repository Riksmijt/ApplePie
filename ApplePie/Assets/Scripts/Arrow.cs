using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Archer archer;
    PlayerMovement playerMovement;
    public bool stunArrowHit = false;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.transform.tag)
        {
            case "Bokser":
                DoDamage(collision.gameObject, 1);
                break;
        }
        if(collision.transform.tag == "Player")
        {
            if (archer.shootingAbilityOne)
            {
                DoDamage(collision.gameObject, 2);
                return;
            }
            if (archer.shootingAbilityTwo)
            {
                DoDamage(collision.gameObject, 1);
                stunArrowHit = true;
                return;
            }
            
            DoDamage(collision.gameObject, 1);
           
        }
        
        
    }
    private void Update()
    {
        stunArrowHit = false;
    }

    private void DoDamage(GameObject target, float damage)
    {
        target.GetComponent<PlayerMovement>().playerHealth -= damage;
    }
    public void SetArcher(Archer newArcher)
    {
        archer = newArcher;
    }
}
