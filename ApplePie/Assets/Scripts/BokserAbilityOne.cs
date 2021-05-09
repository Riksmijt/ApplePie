using UnityEngine;

public class BokserAbilityOne : MonoBehaviour
{
    [SerializeField] private float cooldownTimer;
    [SerializeField] private GameObject forceField;
    private float timer;
    private float abilityTimer = 3;
    private bool isDoingAbility;
    public void ActivateAbility()
    {
        if (timer <= 0)
        {
            isDoingAbility = true;
            timer = cooldownTimer;
        }
       
    }
    private void Update()
    {
        timer -= 1 * Time.deltaTime;
        if (isDoingAbility)
        {
            forceField.SetActive(true);
            abilityTimer -= 1 * Time.deltaTime;
        }
        if (abilityTimer <= 0)
        {
            forceField.SetActive(false);
            isDoingAbility = false;
            abilityTimer = 3;
        }
    }
}
