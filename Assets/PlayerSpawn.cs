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
        gameObject.transform.position = GetSpawnLocation();

        animator.Play("Player_Appearing");
    }

    // Update is called once per frame
    public Vector3 GetSpawnLocation()
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
