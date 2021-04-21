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
    private Music musicManager;
    public bool shootingAbilityOne;
    public bool shootingAbilityTwo;

    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<Music>();
        isShooting = false;
        timer = 0;
        amountArrows = 2;
        shotTimer = 3;
        abilityOneTimer = 9;
        abilityTwoTimer = 4;
    }
    
    void Update()
    {
        shotTimer -= 1 * Time.deltaTime;
        abilityOneTimer -= 1 * Time.deltaTime;
        abilityTwoTimer -= 1 * Time.deltaTime;
    }

    public void OnArrowShoot(InputAction.CallbackContext ctx)
    {
        if (amountArrows >= 1 && shotTimer <= 0)
        {
            GameObject newArrow = Instantiate(arrow, transform.position + transform.forward * 2,transform.rotation);
            newArrow.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
            newArrow.GetComponent<Arrow>().SetArcher(this);
            musicManager.PlayClip("Shooting",1.5f);
            Destroy(newArrow, 2);
            isShooting = true;
            shootingAbilityOne = false;
            shootingAbilityTwo = false;
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
           // musicManager.PlayClip("ArcherFireArrow", 1f);
            GameObject newArrow = Instantiate(arrow, transform.position + transform.forward * 2, transform.rotation);
            newArrow.GetComponent<Arrow>().SetArcher(this);
            newArrow.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
            newArrow.GetComponent<MeshRenderer>().material.color = Color.red;
            Destroy(newArrow, 2);
            shootingAbilityOne = true;
            shootingAbilityTwo = false;
            abilityOneTimer = 9;
        }
    }
    public void AbilityTwo()
    {
        if (abilityTwoTimer <= 0)
        {
            //musicManager.PlayClip("ArcherStunArrow", 1f);
            GameObject newArrow = Instantiate(arrow, transform.position + transform.forward * 2, transform.rotation);
            newArrow.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
            newArrow.GetComponent<MeshRenderer>().material.color = Color.green;
            newArrow.GetComponent<Arrow>().SetArcher(this);
            Destroy(newArrow, 2);
            shootingAbilityOne = false;
            shootingAbilityTwo = true;
            abilityTwoTimer = 4;
        }
    }
}
