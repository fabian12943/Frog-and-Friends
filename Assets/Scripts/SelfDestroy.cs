using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{   
    public float timeInSeconds = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeInSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
