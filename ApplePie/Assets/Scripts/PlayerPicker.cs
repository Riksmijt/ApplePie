using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPicker : MonoBehaviour
{
    public static bool loadArcher;
    public static bool loadBokser;
    [SerializeField] private int scene;
    [SerializeField] private GameObject player;
    public void LoadArcher()
    {
        loadArcher = true;
        loadBokser = false;
        SceneManager.LoadScene(scene);
    }
    public void LoadBokser()
    {
        loadArcher = false;
        loadBokser = true;
        SceneManager.LoadScene(scene);
    }
}
