﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int scene;
    // Start is called before the first frame update
    public void Load()
    {
        Debug.Log("Works");
        SceneManager.LoadScene(scene);
    }
}