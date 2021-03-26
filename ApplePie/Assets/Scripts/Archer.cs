using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Archer : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    private bool isShooting;
    private float timer;
    private float abilityOneTimer;
    private float abilityTwoTimer;
    private int amountArrows;
    private float shotTimer;
    public static bool shootingAbilityOne;
    public static bool shootingAbilityTwo;

    void Start()
    {
        isShooting = false;
        timer = 0;
        amountArrows = 2;
        shotTimer = 3;
        abilityOneTimer = 9;
    }
    
    void Update()
    {
        shotTimer -= 1 * Time.deltaTime;
        abilityOneTimer -= 1 * Time.deltaTime;
    }

    public void OnArrowShoot(InputAction.CallbackContext ctx)
    {
        if (amountArrows >= 1 && shotTimer <= 0)
        {
            GameObject newArrow = Instantiate(arrow, transform.position + transform.forward * 2,transform.rotation);
            newArrow.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
            Destroy(newArrow, 2);
            isShooting = true;
            amountArrows -= 1;
            shotTimer = 3;
            if (amountArrows <= 0)
            {
                amountArrows = 2;
            }
        }
    }
    public void AbilityOne()
    {
        if (abilityOneTimer <= 0)
        {
            GameObject newArrow = Instantiate(arrow, transform.position + transform.forward * 2, transform.rotation);
            newArrow.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
            newArrow.GetComponent<MeshRenderer>().material.color = Color.red;
            Destroy(newArrow, 2);
            shootingAbilityOne = true;
            abilityOneTimer = 9;
        }
    }
    public void AbilityTwo()
    {

    }
}
