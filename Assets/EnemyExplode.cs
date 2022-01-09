using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplode : MonoBehaviour
{
    public GameObject blood;
    public GameObject[] bodyParts;
    public bool respawnEnabled = true;
    public float respawnDelayInSeconds = 4.0f;

    private GameObject enemy;

    void Start()
    {
        enemy = gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerAudioController>().PlayExplodeSound();

            Instantiate(blood, transform.position, Quaternion.identity);
            foreach(GameObject bodyPart in bodyParts) 
            {
                Instantiate(bodyPart, transform.position, Quaternion.identity);
            }
            
            if (respawnEnabled)
            {
                GetComponentInParent<ObjectRespawnerController>().RespawnObject(enemy.transform.position, respawnDelayInSeconds);
            }
            Destroy(enemy);
        }
    }

}
