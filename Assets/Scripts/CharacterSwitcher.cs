using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    int index = 0;
    [SerializeField] GameObject[] players;
    PlayerInputManager manager;

    // Start is called before the first frame update
    private void Start()
    {
        players = Shuffle(players);
        manager = GetComponent<PlayerInputManager>();
        manager.playerPrefab = players[index];
        index += 1;
    }

    public void SwitchNextSpawnCharacter(PlayerInput input)
    {
        manager.playerPrefab = players[index % players.Length];
        index += 1;
    }

    private GameObject[] Shuffle(GameObject[] players)
    {
        for (int t = 0; t < players.Length; t++ )
        {
            GameObject tmp = players[t];
            int r = Random.Range(t, players.Length);
            players[t] = players[r];
            players[r] = tmp;
        }
        return players;
    }
}
