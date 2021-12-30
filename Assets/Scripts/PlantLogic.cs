using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLogic : MonoBehaviour
{
    [SerializeField] private float startTimeBtwShots;
    private float timeBtwShots;

    [SerializeField] private float stoppingDistance;

    [SerializeField] private GameObject project;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        timeBtwShots = startTimeBtwShots;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            Debug.Log("Player within range:" + Vector2.Distance(transform.position, player.position));
            if (timeBtwShots <= 0)
            {
                // Instantiate(project, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    // TODO: anstatt das mit distace zu machen, wäre ne box colli besser der als trigger event fungiert, aka wenn spieler in boxcolli reinkommt anim ändern und bullet instanci
    //prefab 
}
