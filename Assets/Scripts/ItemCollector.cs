using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{

    private Animator anim;
    private enum ItemState { idle, collected, destroyed }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (AnimatorIsPlaying("Collected"))
        {
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

    bool AnimatorIsPlaying(string stateName)
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
