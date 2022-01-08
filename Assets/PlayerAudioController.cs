using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{   
    [Header("Player Name")]
    [SerializeField] AudioClip playerNameShouting;
    [SerializeField] float playerNameShoutingVolume = 1;
    [Header("Player Spawn")]
    [SerializeField] AudioClip playerSpawnSound;
    [SerializeField] float playerSpawnVolume = 1;
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
        ShoutPlayerName();
    }

    public void PlaySpawnSound()
    {
        audioSource.PlayOneShot(playerSpawnSound, playerSpawnVolume);
    }

    public void ShoutPlayerName()
    {
        audioSource.PlayOneShot(playerNameShouting, playerNameShoutingVolume);
    }

    public void PlayExplodeSound()
    {   
        audioSource.volume = playerExplodeVolume;
        audioSource.clip = playerExplodeSounds[Random.Range(0, playerExplodeSounds.Length)];
        audioSource.Play();
    }
}
