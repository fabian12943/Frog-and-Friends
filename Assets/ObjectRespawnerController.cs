using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawnerController : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnObject(Vector3 position, float delayInSeconds)
    {
        StartCoroutine(WaitThenInitiate(position, delayInSeconds));
    }

    private IEnumerator WaitThenInitiate(Vector3 position, float timeinSeconds)
    {
        yield return new WaitForSeconds(timeinSeconds);
        Instantiate(prefab, position, Quaternion.identity, transform);
    }
}
