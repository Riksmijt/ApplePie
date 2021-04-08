using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Winning : MonoBehaviour
{
    [SerializeField] private TMP_Text winText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.blueScore >= 5)
        {
            winText.text = "Blue wins";
        }
        if(Manager.redScore >= 5) 
        {
            winText.text = "Red wins";
        }
    }
}
