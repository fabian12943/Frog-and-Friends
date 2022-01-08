using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerController : MonoBehaviour
{   
    PlayerInputManager inputManager;
    private bool matchRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length == PlayerPrefs.GetInt("noOfPlayers", 1) && matchRunning == false)
        {
            inputManager.DisableJoining();
            GetComponent<Timer>().StartTimer();
            matchRunning = true;
        }
        else
        {
            inputManager.EnableJoining();
        }
    }
}
