using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bokser : MonoBehaviour
{
    public GameObject ab1;

    private bool isDoingAb1 = false;
    private Rigidbody r;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        ab1.SetActive(false);
    }
    IEnumerator StartAb1()
    {
        isDoingAb1 = true;
        ab1.SetActive(true);
        yield return new WaitForSeconds(3);
        ab1.SetActive(false);
        isDoingAb1 = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isDoingAb1)
        {
            
        }
    }
    public void AbbilitieOne()
    {
        if (!isDoingAb1)
        {
            StartCoroutine(StartAb1());
        }
    }
    public void AbbilitieTwo()
    {

    }
}
