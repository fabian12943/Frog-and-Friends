using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLogic : MonoBehaviour
{
    [SerializeField] private float shotSpeed;

    [SerializeField] private float shotDistance;

    [SerializeField] private float engagementDistance;

    [SerializeField] private GameObject project;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < engagementDistance)
        {

        }
    }

    // TODO: Weiter machen Vid Minute 6:24. Es fehlt die eigentliche Schuss logik und was passiert wenn der player getroffen wird -> fabi frgaen
    //prefab 
}
