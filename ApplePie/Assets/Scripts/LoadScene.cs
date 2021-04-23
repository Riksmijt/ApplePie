using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int scene;
    [SerializeField] private Image image;
    [SerializeField] private Slider slider;
    [SerializeField] private Button goBackButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    // Start is called before the first frame update
    private void Start()
    {
        startButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
    }
    public void Load()
    {
        Debug.Log("Works");
        SceneManager.LoadScene(scene);
    }
}
