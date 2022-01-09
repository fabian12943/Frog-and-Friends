using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncerController : MonoBehaviour
{
    [SerializeField] private AudioClip[] spawnAnnouncements;
    [SerializeField] private AudioClip[] deathComments;
    [SerializeField] private AudioClip[] timeAnnouncements;
    [SerializeField] private AudioClip[] resultsComments;
    [SerializeField] private AudioClip[] applePickupComments;
    [SerializeField] private AudioClip[] cherryPickupComments;
    [SerializeField] private AudioClip[] pineapplePickupComments;
    [SerializeField] private AudioClip[] generalPickupComments;
    [SerializeField] private AudioClip[] mushroomKillComments;
    [SerializeField] private AudioClip[] generalKillComments;

    private AudioSource audioSource;

    private int deathCommentsCounter = 0;
    private int applePickupCommentsCounter = 0;
    private int cherryPickupCommentsCounter = 0;
    private int pineapplePickupCommentsCounter = 0;
    private int generalPickupCommentsCounter = 0;
    private int mushroomKillCommentsCounter = 0;
    private int generalKillCommentsCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Shuffle Audioclips
        deathComments = Shuffle(deathComments);
        applePickupComments = Shuffle(applePickupComments);
        cherryPickupComments = Shuffle(cherryPickupComments);
        pineapplePickupComments = Shuffle(pineapplePickupComments);
        generalPickupComments = Shuffle(generalPickupComments);
        mushroomKillComments = Shuffle(mushroomKillComments);
        generalKillComments = Shuffle(generalKillComments);
        
        audioSource = GetComponent<AudioSource>();
        AnnounceSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnnounceSpawn()
    {   
        if (!audioSource.isPlaying)
        {
            audioSource.clip = spawnAnnouncements[(Random.Range(0, spawnAnnouncements.Length))];
            audioSource.Play();
        }
    }

    public void CommentOnPlayerDeath()
    {   
        if (!audioSource.isPlaying)
        {
            audioSource.clip = deathComments[deathCommentsCounter];
            audioSource.Play();
            deathCommentsCounter = deathCommentsCounter == deathComments.Length-1 ? 0 : deathCommentsCounter += 1;
        }
    }

    public void CommentOnItemPickup(string itemName)
    {
        int randomNumber1 = Random.Range(0, 2);
        if (randomNumber1 == 0 && !audioSource.isPlaying) // Only play comment half of the time
        {
            int randomNumber2 = Random.Range(0, 3);
            if (randomNumber2 == 2)
            {
                itemName = "general";
            }

            switch (itemName)
            {
                case "apple":
                    audioSource.clip = applePickupComments[applePickupCommentsCounter];
                    applePickupCommentsCounter = applePickupCommentsCounter == applePickupComments.Length-1 ? 0 : applePickupCommentsCounter += 1;
                    break;
                case "cherry":
                    audioSource.clip = cherryPickupComments[cherryPickupCommentsCounter];
                    cherryPickupCommentsCounter = cherryPickupCommentsCounter == cherryPickupComments.Length-1 ? 0 : cherryPickupCommentsCounter += 1;
                    break;
                case "pineapple":
                    audioSource.clip = pineapplePickupComments[pineapplePickupCommentsCounter];
                    pineapplePickupCommentsCounter = pineapplePickupCommentsCounter == pineapplePickupComments.Length-1 ? 0 : pineapplePickupCommentsCounter += 1;
                    break;
                case "general":
                    audioSource.clip = generalPickupComments[generalPickupCommentsCounter];
                    generalPickupCommentsCounter = generalPickupCommentsCounter == generalPickupComments.Length-1 ? 0 : generalPickupCommentsCounter += 1;
                    break;
            }

            audioSource.Play();
        }
    }

    public void CommentOnEnemyDeath(string enemyName)
    {
        if (!audioSource.isPlaying)
        {   
            int randomNumber2 = Random.Range(0, 3);
            if (randomNumber2 == 2)
            {
                enemyName = "general";
            }

            switch (enemyName)
            {
                case "mushroom": 
                    audioSource.clip = mushroomKillComments[mushroomKillCommentsCounter];
                    mushroomKillCommentsCounter = mushroomKillCommentsCounter == mushroomKillComments.Length-1 ? 0 : mushroomKillCommentsCounter += 1;
                    break;
                case "general":
                    audioSource.clip = generalKillComments[generalKillCommentsCounter];
                    generalKillCommentsCounter = generalKillCommentsCounter == generalKillComments.Length-1 ? 0 : generalKillCommentsCounter += 1;
                    break;
            }

            audioSource.Play();
        }
    }

    public void AnnounceTimeRemaining(int remainingTime)
    {
        if (!audioSource.isPlaying)
        {
            switch (remainingTime)
            {
                case 240: 
                    audioSource.clip = timeAnnouncements[0];
                    break;
                case 180:
                    audioSource.clip = timeAnnouncements[1];
                    break;
                case 120:
                    audioSource.clip = timeAnnouncements[2];
                    break;
                case 60:
                    audioSource.clip = timeAnnouncements[3];
                    break;
                case 30:
                    audioSource.clip = timeAnnouncements[4];
                    break;
                case 10:
                    audioSource.clip = timeAnnouncements[5];
                    break;
            }
            audioSource.Play();
        }
    }

    public void CommentOnMatchResults()
    {   
        audioSource.clip = resultsComments[(Random.Range(0, resultsComments.Length))];
        audioSource.PlayDelayed(8);
    }

    private AudioClip[] Shuffle(AudioClip[] clips)
    {
        for (int t = 0; t < clips.Length; t++ )
        {
            AudioClip tmp = clips[t];
            int r = Random.Range(t, clips.Length);
            clips[t] = clips[r];
            clips[r] = tmp;
        }
        return clips;
    }
}
