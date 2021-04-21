using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    [SerializeField] private GameObject firstButton;
    private void Start()
    {
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(firstButton);
    }
}

