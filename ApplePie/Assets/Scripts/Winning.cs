using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Winning : MonoBehaviour
{
    [SerializeField] private TMP_Text winText;
    void Update()
    {
        if (Manager.blueScore >= 5)
        {
            winText.text = "Blue wins";
        }
        if (Manager.redScore >= 5) 
        {
            winText.text = "Yellow wins";
        }
    }
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    
}
