using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    public bool bokserSpawned;
    public bool archerSpawned;
    [SerializeField] private GameObject Bokser;
    [SerializeField] private GameObject Archer;
    void Update()
    {
        if (PlayerPicker.loadBokser)
        {
            Bokser.SetActive(true);
            Archer.SetActive(false);
        }
        if (PlayerPicker.loadArcher)
        {
            Bokser.SetActive(false);
            Archer.SetActive(true);
        }
    }
}

