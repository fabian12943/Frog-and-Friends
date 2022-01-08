using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Timer : MonoBehaviour
{
    public static float timeRemaining;
    private bool timerIsRunning = false;

    [SerializeField] private Text timeText;

    private void Start() {
        timeRemaining = PlayerPrefs.GetInt("matchDuration", 5) * 30.0f;
    }

    private void Update()
    {
        DisplayTime(timeRemaining);
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {   
                int[] announcerTimes = {240, 180, 120, 60, 30, 10};
                if (Array.Exists(announcerTimes, x => x == (int)timeRemaining))
                {
                    GameObject.Find("Announcer").GetComponent<AnnouncerController>().AnnounceTimeRemaining((int)timeRemaining);
                }
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                GameObject.Find("Announcer").GetComponent<AnnouncerController>().CommentOnMatchResults();
            }
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    private void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
