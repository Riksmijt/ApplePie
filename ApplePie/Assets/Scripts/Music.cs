using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip jumpButton;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(0);
    }

    public void PlayClip(string clipName)
    {
        switch (clipName)
        {
            case "jump":
                audioSource.PlayOneShot(jumpButton);
                break;
        }
    }
}
