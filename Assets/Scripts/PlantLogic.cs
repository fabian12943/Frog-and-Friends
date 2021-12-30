using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLogic : MonoBehaviour
{
    [SerializeField] private float startTimeBtwShots;
    private float timeBtwShots;

    [SerializeField] private GameObject project;

    private bool playerInside = false;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside)
        {
            if (timeBtwShots <= 0)
            {

                Instantiate(project, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }

    //TODO: prefab, enum animation state, switch animation wen trigger and exit 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
}
