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
            }

            if (collision.name.Contains("Cherry"))
            {
                points = points + 2;
            }

            if (collision.name.Contains("Pineapple"))
            {
                points += 5;
            }
            GetComponent<PlayerStats>().points = points;
            pointsText.text = "Points: " + points;
        }
    }   
}
