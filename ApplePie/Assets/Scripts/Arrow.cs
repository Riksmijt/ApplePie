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
                collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(2,false);
                return;
            }
            if (archer.shootingAbilityTwo)
            {
                collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(1,true);

                stunArrowHit = true;
                return;
            }

            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(1,false);

        }
        
        
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
