using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetectScript : MonoBehaviour
{
    GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            GetComponentInParent<ObjectRespawnerController>().RespawnObject(enemy.transform.position, 4);
            Destroy(enemy);
        }
    }
}
