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
        //image.gameObject.SetActive(false);
        //slider.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
    }
    public void Load()
    {
        Debug.Log("Works");
        SceneManager.LoadScene(scene);
    }
    /*public void LoadSetting()
    {
        image.gameObject.SetActive(true);
        slider.gameObject.SetActive(true);
        startButton.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
    }
    public void GoBackToMenu()
    {
        image.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
        startButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
    }*/
}
