using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformLogic : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator anim;

    [SerializeField] private float timeToDrop;
    [SerializeField] private float timeToDelete;

    private enum State {idle, off}

    private State state;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("DropPlatfrom", timeToDrop);
            state = State.off;
            anim.SetInteger("state", (int) state);
            Destroy(gameObject, timeToDelete);
        }
    }

    private void DropPlatfrom()
    {
        rb.isKinematic = false;
    }

    //TODO: off animation noch mal versuchen, maybe geht ja doch
}
