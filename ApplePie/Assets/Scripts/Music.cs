using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource mainTheme;
    
    // Start is called before the first frame update
    void Start()
    {
        mainTheme = GetComponent<AudioSource>();
        mainTheme.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
