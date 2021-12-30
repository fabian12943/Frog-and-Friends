using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoMovement : MonoBehaviour
{   
    public float walkSpeed = 100;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D wallCollider;
    public Collider2D playerDetectionCollider;
    private Animator animator;
    private enum MovementState { idle, running };
    MovementState state;

    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Chasing();
            state = MovementState.running;
        }
        else 
        {
            Chasing();
            state = MovementState.running;
        }
        animator.SetInteger("state", (int)state);
    }

    private void FixedUpdate() {
         mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
    }

    void Patrol()
    {   
        if (mustTurn ||wallCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Chasing()
    {
        if (mustTurn)
        {
            Flip();
        }

        if (wallCollider.IsTouchingLayers(groundLayer))
        {
            animator.SetTrigger("hit_wall");
            Flip();
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
