using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetectScript : MonoBehaviour
{
    GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(Enemy);
    }
}
