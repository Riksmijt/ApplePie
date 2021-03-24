using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Users;

public class Manager : MonoBehaviour
{

    private bool archerIsSpawned;
    private bool bokserIsSpawned;
    private bool tankIsSpawned;
    private bool appleSpawned;
    bool isPressed;
    [SerializeField] private GameObject Apple;
    public static float blueScore;
    public static float redScore;

    // Update is called once per frame
    private void Start()
    {
        blueScore = 0;
        redScore = 0;
        Instantiate(Apple);
    }
    void Update()
    {

        if(PlayerMovement.playerHealth < 0 && PlayerMovement.isSpawned)
        {
            PlayerMovement.playerHealth = 2;
            PlayerMovement.isSpawned = false;
        }
        
    }
}

