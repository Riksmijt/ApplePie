using System.Collections;
using System.Collections.Generic;
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
            Debug.Log(player.GetComponent<PlayerMovement>().playerHealth);
            timer = cooldownTimer;
            Debug.Log("Activated ability two");
        }

    }
    private void Update()
    {
        timer -= 1 * Time.deltaTime;
    }
}
