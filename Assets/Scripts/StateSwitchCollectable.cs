using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSwitchCollectable : MonoBehaviour
{

    private Animator anim;

    private enum ItemState { idle, collected }
    // Start is called before the first frame update
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

    private bool AnimatorIsPlaying(string stateName)
    {
        return anim.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }
}
