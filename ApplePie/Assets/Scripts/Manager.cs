using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Users;
using TMPro;

public class Manager : MonoBehaviour
{
    private bool archerIsSpawned;
    private bool bokserIsSpawned;
    private bool tankIsSpawned;
    private bool appleSpawned;
    bool isPressed;
    [SerializeField] private GameObject Apple;
    [SerializeField] private TMP_Text blueAmountAppels;
    [SerializeField] private TMP_Text redAmountAppels;
    public static float blueScore;
    public static float redScore;
   // public GameObject deadPlayer;

    private void Start()
    {
        blueScore = 0;
        redScore = 0;
        Instantiate(Apple);
    }

    void Update()
    {
       /* PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement.playerHealth < 0 && PlayerMovement.isSpawned)
        {
            playerMovement.playerHealth = 2;
            PlayerMovement.isSpawned = false;
        }*/
        blueAmountAppels.text = blueScore.ToString();
        redAmountAppels.text = redScore.ToString();
    }
}

