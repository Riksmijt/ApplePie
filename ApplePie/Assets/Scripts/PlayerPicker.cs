using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPicker : MonoBehaviour
{
    [SerializeField] private int scene;
    // Start is called before the first frame update
    public void Load()
    {
        Debug.Log("Works");
        SceneManager.LoadScene(scene);
    }
}
