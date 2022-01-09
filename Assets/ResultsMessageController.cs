using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ResultsMessageController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> leaderboardPlaces;

    [SerializeField]
    private AudioClip victorySound;

    private GameObject resultsMessage;
    private bool resultsCalculated = false;

    // Start is called before the first frame update
    void Start()
    {
        resultsMessage = GetChildWithName(gameObject, "ResultsMessage");
        resultsMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.timeRemaining == 0 && !resultsCalculated)
        {
            Time.timeScale = 0;
            resultsMessage.SetActive(true);
            CalculatePlayerScores();
            resultsCalculated = true;

            GameObject.Find("Background Music").GetComponent<BackgroundAudioController>().PlayAudioClip(victorySound);
        }
    }

    void CalculatePlayerScores()
    {
        List<GameObject> players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));
        players = players.OrderByDescending(player=>player.GetComponent<PlayerStats>().points).ThenBy(player=>player.GetComponent<PlayerStats>().deaths).ThenBy(player=>player.name).ToList<GameObject>();

        for (int i = 0; i < players.Count; i++)
        {
            leaderboardPlaces[i].GetComponent<FillInLeaderboardRow>().FillRow(players[i]);
        }
        for (int i = players.Count; i < 4; i++)
        {
            leaderboardPlaces[i].GetComponent<FillInLeaderboardRow>().FillRow(null);
        }
    }

     public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    private GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null) 
        {
            return childTrans.gameObject;
        } 
        else 
        {
            return null;
        }
    }
}
