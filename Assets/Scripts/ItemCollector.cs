using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private Animator anim;
    private enum ItemState { idle, collected, destroyed }

    private int points = 0;

    [SerializeField] private Text pointsText;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (AnimatorIsPlaying("Collected"))
        {
            if (name.Contains("Apple"))
            {
                points++;
            }

            if (name.Contains("Cherry"))
            {
                points = points + 2;
            }

            if (name.Contains("Pineapple"))
            {
                points += 5;
            }
            pointsText.text = "Points: " + points;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        ItemState state = ItemState.idle;

        if (collision.gameObject.CompareTag("Player"))
        {
            state = ItemState.collected;
        }

        anim.SetInteger("state", (int)state);
    }
    
    //TODO: Put Script into player maybe 

    bool AnimatorIsPlaying(string stateName)
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
