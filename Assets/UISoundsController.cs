using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundsController : MonoBehaviour
{
    [SerializeField] AudioClip buttonOnClickSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(buttonOnClickSound);
    }
}
