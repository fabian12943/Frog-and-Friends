using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoMovement : MonoBehaviour
{   
    public float mMovementSpeed = 5.0f;
    public bool bIsGoingRight = true;
    public float mRaycastingDistance = 1.5f;

    private SpriteRenderer _mSpriteRenderer;
    private Animator animator;

    public bool mustPatrol = true;

    // Start is called before the first frame update
    void Start()
    {
        _mSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        _mSpriteRenderer.flipX = bIsGoingRight;
    }

    
    void Update()
    {
        if (mustPatrol)
        {
            animator.SetInteger("state", 1);
            // if the ennemy is going right, get the vector pointing to its right
            Vector3 directionTranslation = (bIsGoingRight) ? transform.right : -transform.right; 
            directionTranslation *= Time.deltaTime * mMovementSpeed;

            transform.Translate(directionTranslation);

            CheckForWalls();
        }
        else
        {
            animator.SetInteger("state", 0);
        }
    }

    private void CheckForWalls()
    {
        Vector3 raycastDirection = (bIsGoingRight) ? Vector3.right : Vector3.left;

        // Raycasting takes as parameters a Vector3 which is the point of origin, another Vector3 which gives the direction, and finally a float for the maximum distance of the raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position + raycastDirection * mRaycastingDistance - new Vector3(0f, 0.25f, 0f), raycastDirection, 0.075f);

        // if we hit something, check its tag and act accordingly
        if (hit.collider != null)
        {
            if (hit.transform.tag == "Terrain")
            {
                mustPatrol = false;
                animator.Play("Rhino_Hit_Wall");
                StartCoroutine(Flip());
            }
        }
    }

    IEnumerator Flip()
    {
        yield return new WaitForSeconds(0.75f);
        bIsGoingRight = !bIsGoingRight;
        _mSpriteRenderer.flipX = bIsGoingRight;
        mustPatrol = true;
    }

}
