using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JoinPlayerMessageController : MonoBehaviour
{
    TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetChildWithName(gameObject, "Remaining Players").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int spawnedPlayersAmount = GameObject.FindGameObjectsWithTag("Player").Length;
        int playersAmountTotal = PlayerPrefs.GetInt("noOfPlayers", 1);
        if (spawnedPlayersAmount == playersAmountTotal)
        {
            gameObject.SetActive(false);
        }
        else 
        {
            gameObject.SetActive(true);
        }

        if (playersAmountTotal - spawnedPlayersAmount == 1)
        {
            textMesh.text = "Waiting for 1 more player.";
        }
        else
        {
            textMesh.text = "Waiting for " + (playersAmountTotal - spawnedPlayersAmount) + " more players.";
        }
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
