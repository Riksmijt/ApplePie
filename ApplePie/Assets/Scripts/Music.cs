using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpButton;
    [SerializeField] private AudioClip shootButton;
    [SerializeField] private AudioClip hitButton;
    [SerializeField] private AudioClip damage;


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
            case "Shooting":
                audioSource.PlayOneShot(shootButton);
                break;
            case "Hitting":
                audioSource.PlayOneShot(hitButton);
                break;
            case "Damage":
                audioSource.PlayOneShot(damage);
                break;


        }
    }
}
