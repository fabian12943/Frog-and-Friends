using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            GetComponent<Camera>().cullingMask = LayerMask.GetMask("Nothing");
        }
        else 
        {
            GetComponent<Camera>().cullingMask = -1;
        }
    }
}
