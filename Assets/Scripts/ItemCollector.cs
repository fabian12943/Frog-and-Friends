using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int points = 0;

    [SerializeField] private Text pointsText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
           if (collision.name.Contains("Apple"))
            {
                points++;
                GameObject.Find("Announcer").GetComponent<AnnouncerController>().CommentOnItemPickup("apple");
            }

            if (collision.name.Contains("Cherry"))
            {
                points = points + 2;
                GameObject.Find("Announcer").GetComponent<AnnouncerController>().CommentOnItemPickup("cherry");
            }

            if (collision.name.Contains("Pineapple"))
            {
                points += 5;
                GameObject.Find("Announcer").GetComponent<AnnouncerController>().CommentOnItemPickup("pineapple");
            }
            GetComponent<PlayerStats>().points = points;
            pointsText.text = "Points: " + points;
        }
    }   
}
