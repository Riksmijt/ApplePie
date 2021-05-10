using UnityEngine;

public class Arrow : MonoBehaviour
{
    Archer archer;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.transform.tag)
        {
            case "Bokser":
                DoDamage(collision.gameObject, 1);
                break;
        }
        if (collision.transform.tag == "Player")
        {
            if (archer.ShootingAbilityOne)
            { 
                collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(2,false);
                return;
            }
            if (archer.ShootingAbilityTwo)
            {
                collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(1, true);
                return;
            }
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(1,false);
        }
    }

    private void DoDamage(GameObject target, float damage)
    {
        target.GetComponent<PlayerMovement>().PlayerHealth -= damage;
    }
    public void SetArcher(Archer newArcher)
    {
        archer = newArcher;
    }
}
