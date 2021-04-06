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
    [SerializeField] private AudioClip archerFireArrow;
    [SerializeField] private AudioClip archerStunArrow;
    [SerializeField] private AudioClip bokserForceField;
    [SerializeField] private AudioClip bokserForceArrow;
    [SerializeField] private AudioClip applePickUp;
    [SerializeField] private AudioClip pointAdded;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(0);
    }
    public void PlayClip(string clipName, float volume)
    {
        switch (clipName)
        {
            case "jump":
                audioSource.PlayOneShot(jumpButton,volume);
                break;
            case "Shooting":
                audioSource.PlayOneShot(shootButton, volume);
                break;
            case "Hitting":
                audioSource.PlayOneShot(hitButton, volume);
                break;
            case "Damage":
                audioSource.PlayOneShot(damage, volume);
                break;
            case "ArcherFireArrow":
                audioSource.PlayOneShot(archerFireArrow, volume);
                break;
            case "ArcherStunArrow":
                audioSource.PlayOneShot(archerStunArrow, volume);
                break;
            case "BokserForceField":
                audioSource.PlayOneShot(bokserForceField, volume);
                break;
            case "BokserForceArrow":
                audioSource.PlayOneShot(bokserForceArrow, volume);
                break;
            case "ApplePickedUp":
                audioSource.PlayOneShot(applePickUp, volume);
                break;
            case "PointAdded":
                audioSource.PlayOneShot(pointAdded, volume);
                break;


        }
    }
}
