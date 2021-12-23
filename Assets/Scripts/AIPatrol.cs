using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{   
    public float walkSpeed = 100;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    private Animator animator;
    private enum MovementState { idle, running, jumping, falling, hit };
    MovementState state;

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
        animator.SetInteger("state", (int)state);
    }

    private void FixedUpdate() {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {   
        if (mustTurn ||bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        else {
            state = MovementState.running;
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
