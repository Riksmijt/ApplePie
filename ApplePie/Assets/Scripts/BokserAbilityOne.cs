using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BokserAbilityOne : MonoBehaviour
{
    [SerializeField] private float cooldownTimer;
    private float timer;
    public void ActivateAbility()
    {
        if (timer <= 0)
        {
            timer = cooldownTimer;
            Debug.Log("Activated ability one");
        }
       
    }
    private void Update()
    {
        timer -= 1 * Time.deltaTime;
    }
}
