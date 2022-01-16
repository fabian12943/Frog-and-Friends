using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoMovement : MonoBehaviour
{   
    public float mMovementSpeed = 5.0f;
    public bool bIsGoingRight = true;
    public float mRaycastingDistance = 0.1f;

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
            if (!CheckForWalls()){
                animator.SetInteger("state", 1);
                // if the ennemy is going right, get the vector pointing to its right
                Vector3 directionTranslation = (bIsGoingRight) ? transform.right : -transform.right; 
                directionTranslation *= Time.deltaTime * mMovementSpeed;

                transform.Translate(directionTranslation);
            }
        }
        else
        {
            animator.SetInteger("state", 0);
        }
    }

    private bool CheckForWalls()
    {
        Vector3 raycastDirection = (bIsGoingRight) ? Vector3.right : Vector3.left;

        // Raycasting takes as parameters a Vector3 which is the point of origin, another Vector3 which gives the direction, and finally a float for the maximum distance of the raycast
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position + raycastDirection * mRaycastingDistance - new Vector3(0f, 0.25f, 0f), raycastDirection, 0.15f);

        // if we hit something, check its tag and act accordingly
        if (hits.Length != 0)
        {
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.transform.tag == "Terrain")
                {
                    mustPatrol = false;
                    animator.Play("Rhino_Hit_Wall");
                    StartCoroutine(Flip());
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator Flip()
    {
        yield return new WaitForSeconds(0.75f);
        bIsGoingRight = !bIsGoingRight;
        _mSpriteRenderer.flipX = bIsGoingRight;
        mustPatrol = true;
    }

}
