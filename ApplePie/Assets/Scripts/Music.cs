using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Music : MonoBehaviour
{
    public AudioSource mainTheme;
    public AudioClip aButton;
    // Start is called before the first frame update
    void Start()
    {
        mainTheme = GetComponent<AudioSource>();
        mainTheme.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.aButton.wasPressedThisFrame)
        {
            mainTheme.PlayOneShot(aButton);
        }
    }
}
