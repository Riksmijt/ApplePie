using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bokser : MonoBehaviour
{
    private float coolDownTimeAb1 = 0;
    private float coolDownTimeAb2 = 0;
    private float canStartAb1 = 0;
    private float canStartAb2 = 0;

    [SerializeField] private GameObject ab1;
    [SerializeField] private GameObject ab2;

    private bool ab1Active;
    private bool isDoingAb1;
    private bool isDoingAb2;
    private Music musicManager;
 
    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<Music>();
        ab1.SetActive(false);
        ab2.SetActive(false);
        isDoingAb1 = false;
        isDoingAb2 = false;
    }

    void Update()
    {
       /* if (isDoingAb1)
        {
            coolDownTimeAb1 += 1 * Time.deltaTime;
            canStartAb1 += 1 * Time.deltaTime;
        }
        if(coolDownTimeAb1 >= 0.5f)
        {
 
            ab1.SetActive(false);
            coolDownTimeAb1 = 0;
        }
        if(canStartAb1 >= 15)
        {
            isDoingAb1 = false;
            canStartAb1 = 0;
        }

        if (isDoingAb2)
        {
            coolDownTimeAb2 += 1 * Time.deltaTime;
            canStartAb2 += 1 * Time.deltaTime;
        }
        if (coolDownTimeAb2 >= 0.5f)
        {

            ab2.SetActive(false);
            coolDownTimeAb2 = 0;
        }
        if (canStartAb2 >= 10)
        {
            isDoingAb2 = false;
            canStartAb2 = 0;
        }*/
    }

   
}
