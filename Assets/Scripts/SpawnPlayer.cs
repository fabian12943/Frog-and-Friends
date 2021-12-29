using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private GameObject player;
    public void OnSpawnAtLocation()
    {
        Instantiate(player, spawnLocation.transform.position, Quaternion.identity);
    }
    //TODO: Fix spawn: musst irgendwie mit characterswitch verbinden oder es irgendwie in den input manager packen, oder es irgendwie in den player manager packen
    //allein funktioniert es aber ohne switcher und ohne player limit
}
