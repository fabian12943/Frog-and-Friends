using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainCreator : MonoBehaviour
{
    public int chainLength = 1;
    public float distanceBetweenPrefabs = 0.4f;
    public Transform prefab;
    public bool horizontal = true;

    // Start is called before the first frame update
    void Start()
    {
        float parentX = transform.position.x;
        float parentY = transform.position.y;
        for (int i = 1; i < chainLength; i++)
        {   
            if (horizontal)
            {
                Instantiate(prefab, new Vector3(parentX + i * distanceBetweenPrefabs, parentY), Quaternion.identity, transform);
            } else 
            {
                Instantiate(prefab, new Vector3(parentX , parentY - i * distanceBetweenPrefabs), Quaternion.identity, transform);
            }
        }
    }

}
