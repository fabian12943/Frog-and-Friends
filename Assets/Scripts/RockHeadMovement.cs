using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHeadMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    private float startPosX;
    private float startPosY;
    private bool onReturn = false;
    private float speed = 0f;

    [SerializeField] private float acceleration = 0.1f;
    private Animator animator;

    private enum MovementState { blink, up, down };

    MovementState state;

    private void Start()
    {
        animator = GetComponent<Animator>();
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            atWaypoint();
            if (!onReturn)
            { //Bestimmt nächsten Waypoint
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = waypoints.Length - 1;
                    onReturn = true;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 0;
                    onReturn = false;
                }
            }
        }else
        {
            resetAnimation();
        }
        speed += acceleration;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

    private void atWaypoint() //TODO: determine which waypoint, include remaining animations, create prefab
    {
        speed = 0f;
        state = MovementState.down;
        animator.SetInteger("state", (int)state);
    }

    private void determineNextState()
    {
        if (transform.position.y > startPosY)
        {
            state = MovementState.up;
        }
        else
        {
            state = MovementState.down;
        }
    }

    private void resetAnimation()
    {
        state = MovementState.blink;
        animator.SetInteger("state", (int)state);
    }
}
