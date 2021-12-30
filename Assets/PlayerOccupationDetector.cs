using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOccupationDetector : MonoBehaviour
{
    public bool spawnpointOccupied = false;
    public int playersInRange = 0;

    private void Update() {
        if (playersInRange > 0) {
            spawnpointOccupied = true;
        } else
        {
            spawnpointOccupied = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
       if (other.gameObject.tag == "Player")
       {
           playersInRange += 1;
       }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            playersInRange -= 1;
        }
    }
}
