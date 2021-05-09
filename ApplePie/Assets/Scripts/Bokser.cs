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
}
