using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExplode : MonoBehaviour
{
    public GameObject blood;
    public GameObject[] bodyParts;
    public Renderer playerRenderer;

    public float respawnDelayInSeconds = 1.5f;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Deadly")
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            foreach(GameObject bodyPart in bodyParts) 
            {
                Instantiate(bodyPart, transform.position, Quaternion.identity);
            }
            
            playerRenderer.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            StartCoroutine(Respawn(respawnDelayInSeconds));
        }
    }

    IEnumerator Respawn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        playerRenderer.GetComponent<Renderer>().enabled = true;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        gameObject.transform.position = gameObject.GetComponent<PlayerSpawn>().GetSpawnLocation();
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
