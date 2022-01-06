using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] enemys;
    public float minSpawnDelay = 3.0f;
    public float maxSpawnDelay = 8.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy(){
        while(true)
        {
            int random = Random.Range(0, enemys.Length);
            Instantiate(enemys[random], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity, transform);
            float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(delay);
        }
    }
}
