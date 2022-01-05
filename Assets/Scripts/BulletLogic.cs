using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{

    [SerializeField] private float speed;

    [SerializeField] private float shotDistance;

    [SerializeField] private bool flipped;

    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        if (flipped)
        {
            shotDistance *= -1;
        }
        target = new Vector2(shotDistance, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        if (flipped)
        {
            if (transform.position.x == shotDistance)
            {
                Destroy(gameObject);
            }
        }
        else if (transform.position.x >= shotDistance)
        {
            Destroy(gameObject);
        }
    }
}
