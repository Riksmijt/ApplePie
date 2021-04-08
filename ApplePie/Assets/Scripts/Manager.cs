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
    [SerializeField] private int scene;
    private bool archerIsSpawned;
    private bool bokserIsSpawned;
    private bool tankIsSpawned;
    private bool appleSpawned;
    bool isPressed;
    private int randomPicker;
    [SerializeField] private GameObject Apple;
    [SerializeField] private TMP_Text blueAmountAppels;
    [SerializeField] private TMP_Text redAmountAppels;
    [SerializeField] private GameObject bokser;
    [SerializeField] private GameObject archer;
    public static float blueScore;
    public static float redScore;
    private PlayerMovement playermovement;
   // public GameObject deadPlayer;

    private void Start()
    {
        randomPicker = Random.Range(0, 1);
        blueScore = 0;
        redScore = 0;
        Instantiate(Apple);
    }
    private void Awake()
    {
        var players = FindObjectOfType<PlayerMovement>();
    }
    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log(Gamepad.current);
        playermovement = playerInput.gameObject.GetComponent<PlayerMovement>();
        if(playermovement.index == 0) 
        {
            Debug.Log("Archer");
        }
    }
    void Update()
    {
       if(blueScore >= 5 || redScore >= 5)
        {
            SceneManager.LoadScene(scene);
        }
        blueAmountAppels.text = blueScore.ToString();
        redAmountAppels.text = redScore.ToString();
    }
}

