using UnityEngine;

public class BokserAbility : MonoBehaviour
{
    [SerializeField] private float force;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Rigidbody>().AddForce(Vector3.back * force);
            collision.transform.GetComponent<PlayerMovement>().TakeDamage(1,false);
            
        }
    }
}
