using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerController : MonoBehaviour
{   
    PlayerInputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == PlayerPrefs.GetInt("noOfPlayers", 1))
        {
            inputManager.DisableJoining();
            GetComponent<Timer>().StartTimer();
        }
        else
        {
            inputManager.EnableJoining();
        }
    }
}
