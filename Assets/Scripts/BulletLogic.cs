using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{

    [SerializeField] private float speed;

    [SerializeField] private float shotDistance;

    private Vector2 target;
    private float plantMouth;

    // Start is called before the first frame update
    void Start()
    {
        plantMouth = transform.position.y + 0.34f; //TODO: muss noch richtig angepasst werden nervig
        target = new Vector2(shotDistance, plantMouth);
        transform.position = new Vector2(transform.position.x, plantMouth);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    // TODO: destroy condition, boxcollider, deadly tag 
}
