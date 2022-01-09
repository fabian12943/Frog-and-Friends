using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 30f;
    [SerializeField] private float groundDetectionDistance = 0.5f;

    private SpriteRenderer sprite;
    private Animator animator;
    private BoxCollider2D coll;
    private float horizontal;

    private enum MovementState { idle, running, jumping, falling, hit };

    void Start() {
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == PlayerPrefs.GetInt("noOfPlayers", 1))
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        MovementState state;

        if (horizontal > 0f)
        {
            state = MovementState.running;

            sprite.flipX = false;
        }
        else if (horizontal < 0f)
        {
            state = MovementState.running;

            sprite.flipX = true;
        }
        else 
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            GetComponent<PlayerAudioController>().PlayJumpSound();
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
           rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, groundDetectionDistance, groundLayer);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }
}
