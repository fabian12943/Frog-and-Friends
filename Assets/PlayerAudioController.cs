using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{   
    [Header("Player Explode")]
    [SerializeField] AudioClip[] playerExplodeSounds;
    [SerializeField] float playerExplodeVolume = 1;
    [Header("Player Jump")]
    [SerializeField] AudioClip playerJumpSound;
    [SerializeField] float playerJumpVolume = 1;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayExplodeSound()
    {   
        audioSource.volume = playerExplodeVolume;
        audioSource.clip = playerExplodeSounds[Random.Range(0, playerExplodeSounds.Length)];;
        audioSource.Play();
    }

}
