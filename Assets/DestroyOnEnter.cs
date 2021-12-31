using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnter : MonoBehaviour
{
    public string tagOfObjectToDestroy;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == tagOfObjectToDestroy) {
            Destroy(other.gameObject);
        }
    }
}
