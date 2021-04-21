using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayer : MonoBehaviour
{
    public bool bokserSpawned;
    public bool archerSpawned;
    [SerializeField] private GameObject Bokser;
    [SerializeField] private GameObject Archer;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
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

