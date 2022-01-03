using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLogic : MonoBehaviour
{
    [SerializeField] private float startTimeBtwShots;
    private float timeBtwShots;

    [SerializeField] private GameObject project;

    enum State { idle, attack }

    private State state;

    private Animator animator;
    private bool playerInside = false;

    [SerializeField] private bool flipped;

    private Vector3 bulletPosition;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        animator = GetComponent<Animator>();
        
        if (flipped)
        {
            bulletPosition = new Vector3(transform.position.x - 1f, transform.position.y + .16f, -100);
        }else
        {
            bulletPosition = new Vector3(transform.position.x + 1.12f, transform.position.y + .28f, -100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside)
        {
            if (timeBtwShots <= 0)
            {

                Instantiate(project, bulletPosition, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = true;
            state = State.attack;
        }
        animator.SetInteger("state", (int)state);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInside = false;
            state = State.idle;
        }
        animator.SetInteger("state", (int)state);
    }
}
