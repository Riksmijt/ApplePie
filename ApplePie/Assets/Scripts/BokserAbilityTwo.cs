using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BokserAbilityTwo : MonoBehaviour
{
    [SerializeField] private float cooldownTimer;
    private float timer;
    public void ActivateAbility()
    {
        if (timer <= 0)
        {
            GetComponent<PlayerMovement>().playerHealth += 2;
            timer = cooldownTimer;
            Debug.Log("Activated ability two");
        }

    }
    private void Update()
    {
        timer -= 1 * Time.deltaTime;
    }
}
