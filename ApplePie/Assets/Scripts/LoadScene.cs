using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int scene;
    [SerializeField] private Image image;
    [SerializeField] private Slider slider;
    [SerializeField] private Button goBackButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Button settingsButton;
    private void Start()
    {
        startButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
    }
    public void Load()
    {
        SceneManager.LoadScene(scene);
    }
}
