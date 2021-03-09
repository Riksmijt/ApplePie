using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Users;

public class Manager : MonoBehaviour
{

    [SerializeField] private GameObject archer;
    [SerializeField] private GameObject bokser;
    //[SerializeField] private GameObject tank;

    private bool archerIsSpawned;
    private bool bokserIsSpawned;
    private bool tankIsSpawned;
    bool isPressed;

    public const string PlayerJoinedMessage = "OnPlayerJoined";
    // Start is called before the first frame update
    void Start()
    {
      
    }
    void Archer()
    {
      
    }
    void Bokser()
    {
        
       
    }
    public void EnableJoining()
    {
     
   }
    
   // Update is called once per frame
   void Update()
   {



    }
}

