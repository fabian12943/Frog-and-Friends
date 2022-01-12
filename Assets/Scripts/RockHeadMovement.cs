using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHeadMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    private float startPosX;
    private float startPosY;
    private float speed = 0f;

    [SerializeField] private float acceleration;
    private Animator animator;

    private enum MovementState { blink, up, down, left, rigth };

    MovementState state;

    private void Start()
    {
        animator = GetComponent<Animator>();
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }
    private void FixedUpdate()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            atWaypoint();
            //Bestimmt nächsten Waypoint
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        else
        {
            resetAnimation();
        }
        speed += acceleration;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

    private void atWaypoint()
    {
        speed = 0f;
        determineNextState();
        animator.SetInteger("state", (int)state);
    }

    private void determineNextState()
    {
        if (transform.position.y > startPosY & Mathf.Abs(transform.position.x - startPosX) < .1f)
        {
            state = MovementState.up;
            startPosX = transform.position.x;
            startPosY = transform.position.y;
        }
        else if (transform.position.y < startPosY & Mathf.Abs(transform.position.x - startPosX) < .1f)
        {
            state = MovementState.down;
            startPosX = transform.position.x;
            startPosY = transform.position.y;
        }
        else if (transform.position.x > startPosX & Mathf.Abs(transform.position.y - startPosY) < .1f)
        {
            state = MovementState.rigth;
            startPosX = transform.position.x;
            startPosY = transform.position.y;
        }
        else if (transform.position.x < startPosX & Mathf.Abs(transform.position.y - startPosY) < .1f)
        {
            state = MovementState.left;
            startPosX = transform.position.x;
            startPosY = transform.position.y;
        }
    }

    private void resetAnimation()
    {
        state = MovementState.blink;
        animator.SetInteger("state", (int)state);
    }
}
