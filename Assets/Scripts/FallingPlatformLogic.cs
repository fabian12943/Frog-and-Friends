using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformLogic : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator anim;

    [SerializeField] private float timeToDrop = 0.3f;
    [SerializeField] private float timeToDelete = 1.0f;
    [SerializeField] private float respawnDelay = 2.0f;

    private enum State { idle, off }

    private State state;

    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spawnPosition = gameObject.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("DropPlatfrom", timeToDrop);
            state = State.off;
            anim.SetInteger("state", (int)state);
            GetComponentInParent<ObjectRespawnerController>().RespawnObject(spawnPosition, respawnDelay);
            Destroy(gameObject, timeToDelete);
        }
    }

    private void DropPlatfrom()
    {
        rb.isKinematic = false;
    }

}
