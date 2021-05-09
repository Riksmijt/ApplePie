using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonHover : MonoBehaviour
{
    [SerializeField] private int scene;
    [SerializeField] private GameObject archer;
    [SerializeField] private GameObject bokser;
    [SerializeField] private EventSystem eventSystem;
    private void Update()
    {
        if (eventSystem.currentSelectedGameObject.tag == "ArcherButton") 
        {
            archer.SetActive(true);
            bokser.SetActive(false);
        }
        if (eventSystem.currentSelectedGameObject.tag == "BokserButton")
        {
            archer.SetActive(false);
            bokser.SetActive(true);
        }
    }
   
}

