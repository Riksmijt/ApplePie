using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip jumpButton;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(0);
    }

    // Update is called once per frame
    public void PlayClip(string clipName)
    {
        switch (clipName)
        {
            case "jump":
                audioSource.PlayOneShot(jumpButton);
                break;
        }
    }
    void Update()
    {

    }
    
}
