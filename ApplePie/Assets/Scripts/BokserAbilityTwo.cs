using UnityEngine;

public class BokserAbilityTwo : MonoBehaviour
{
    [SerializeField] private float cooldownTimer;
    [SerializeField] private GameObject player;
    private float timer;
    public void ActivateAbility()
    {
        if (timer <= 0)
        {
            player.GetComponent<PlayerMovement>().playerHealth += 2;
            timer = cooldownTimer;
        }

    }
    private void Update()
    {
        timer -= 1 * Time.deltaTime;
    }
}
