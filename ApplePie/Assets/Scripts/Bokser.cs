using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bokser : MonoBehaviour
{
    public float coolDownTime = 0;

    public GameObject ab1;
    public GameObject ab2;

    private bool ab1Active;
    private bool isDoingAb1 = false;
    private bool isDoingAb2 = false;
 
    // Start is called before the first frame update
    void Start()
    {
        ab1.SetActive(false);
        ab2.SetActive(false);
        isDoingAb1 = true;
        isDoingAb2 = true;
    }
    IEnumerator StartAb(GameObject ab, bool whatAb)
    {
        whatAb = true;
        yield return new WaitForSeconds(3);
        ab.SetActive(false);
        whatAb = false;
    }
    IEnumerator AccesAb()
    {
        ab1Active = true;
        yield return new WaitForSeconds(10);
        ab1Active = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void AbilityOne()
    {
        if (!isDoingAb1)
        {
            ab1.SetActive(true);
            StartCoroutine(StartAb(ab1,isDoingAb1));
        }
    }
    public void AbbilitieTwo()
    {
        if (!isDoingAb2)
        {
            ab2.SetActive(true);
            StartCoroutine(StartAb(ab2, isDoingAb2));
        }
    }
}
