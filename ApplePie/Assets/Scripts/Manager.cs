using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Users;
using TMPro;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    [SerializeField] private int scene;
    [SerializeField] private GameObject Apple;
    [SerializeField] private TMP_Text blueAmountAppels;
    [SerializeField] private TMP_Text redAmountAppels;
    [SerializeField] private GameObject bokser;
    [SerializeField] private GameObject archer;
    public static float blueScore;
    public static float redScore;
    private PlayerMovement playermovement;
    private void Start()
    {
        
        blueScore = 0;
        redScore = 0;
        Instantiate(Apple);
    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        if (playerInput.playerIndex == 1)
        {
            player1 = playerInput.gameObject;
            player1.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        if (playerInput.playerIndex == 2)
        {
            player2 = playerInput.gameObject;
            player2.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        playermovement = playerInput.gameObject.GetComponent<PlayerMovement>();
        if (playermovement.index == 0) 
        {

        }
    }
    void Update()
    {
       if (blueScore >= 5 || redScore >= 5)
        {
            SceneManager.LoadScene(scene);
        }
        blueAmountAppels.text = blueScore.ToString();
        redAmountAppels.text = redScore.ToString();
    }
}

