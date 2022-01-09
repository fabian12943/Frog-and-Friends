using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioController : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] backgroundSongs;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {   
        audioSource = GetComponent<AudioSource>();

        // Set volume
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }

        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");

        // Play random song
        AudioSource audio = GetComponent<AudioSource>();
        if (!audioSource.isPlaying)
        {
            audio.clip = backgroundSongs[Random.Range(0, backgroundSongs.Length)];
            audio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = backgroundSongs[Random.Range(0, backgroundSongs.Length)];
            audioSource.Play();
        }
    }

    public void PlayAudioClip(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

}
