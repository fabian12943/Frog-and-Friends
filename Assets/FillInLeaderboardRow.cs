using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FillInLeaderboardRow : MonoBehaviour
{
    TextMeshProUGUI playerName;
    TextMeshProUGUI deathCount;
    TextMeshProUGUI pointsCount;
    Image playerImage;
    
    // Start is called before the first frame update
    void Start()
    {
        playerName = GetChildWithName(gameObject, "Name").GetComponent<TextMeshProUGUI>();
        deathCount = GetChildWithName(gameObject, "Deaths").GetComponent<TextMeshProUGUI>();
        pointsCount = GetChildWithName(gameObject, "Points").GetComponent<TextMeshProUGUI>();
        playerImage = GetChildWithName(gameObject, "Image").GetComponent<Image>();
    }

    public void FillRow(GameObject player) 
    {
        if (player == null)
        {
            playerName.text = "---";
            pointsCount.text = "---";
            deathCount.text = "---";
            playerImage.enabled = false;
        }
        else
        {
            playerName.text = player.GetComponent<PlayerStats>().name;
            pointsCount.text = "Points: " + player.GetComponent<PlayerStats>().points;
            deathCount.text = "Deaths: " + player.GetComponent<PlayerStats>().deaths;
            playerImage.sprite = player.GetComponent<PlayerStats>().image;
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
