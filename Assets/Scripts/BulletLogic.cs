using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{

    [SerializeField] private float speed;

    [SerializeField] private float shotDistance;

    private Vector2 target;
    // private Vector2 plantMouth;

    // Start is called before the first frame update
    void Start()
    {
        // plantMouth = new Vector2(transform.position.x + 1.12f, transform.position.y + 0.2f); //TODO: muss noch richtig angepasst werden nervig
        target = new Vector2(shotDistance, transform.position.y);
        // transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        if (transform.position.x >= shotDistance)
        {
            Destroy(gameObject);
        }
    }

    // TODO: deadly tag 
}
