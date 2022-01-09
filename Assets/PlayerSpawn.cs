using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{   
    private GameObject[] spawnpoints;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {   
        animator = GetComponentInChildren<Animator>();

        spawnpoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
        gameObject.transform.position = GetRandomSpawnLocation();

        animator.Play("Player_Appearing");
        GetComponent<PlayerAudioController>().PlaySpawnSound();
    }

    public Vector3 GetRandomSpawnLocation()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
        spawnpoints = Shuffle(spawnpoints);
        foreach (GameObject spawnpoint in spawnpoints)
        {
            if (!spawnpoint.GetComponent<PlayerOccupationDetector>().spawnpointOccupied)
            {
                return spawnpoint.transform.position + new Vector3(1.0f, 0, 0);
            }
        }
        return spawnpoints[0].transform.position;
    }

    public Vector3 GetNearestSpawnLocation()
    {
        spawnpoints = GameObject.FindGameObjectsWithTag("Spawnpoint");
        GameObject closestSpawnpointSoFar = null;
        float closestDistanceSoFar = float.MaxValue;
        foreach (GameObject spawnpoint in spawnpoints)
        {
             Vector3 diff = spawnpoint.transform.position - gameObject.transform.position;
             float curDistance = Mathf.Abs(diff.sqrMagnitude);
            if (curDistance < closestDistanceSoFar )
            {
                closestSpawnpointSoFar = spawnpoint;
                closestDistanceSoFar = curDistance;
            }
        }
        return closestSpawnpointSoFar.transform.position;
    }

    public static GameObject[] Shuffle (GameObject[] aList) {
 
        System.Random _random = new System.Random ();

        GameObject myGO;

        int n = aList.Length;
        for (int i = 0; i < n; i++)
        {
            // NextDouble returns a random number between 0 and 1.
            // ... It is equivalent to Math.random() in Java.
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = aList[r];
            aList[r] = aList[i];
            aList[i] = myGO;
        }

        return aList;
     }
}
