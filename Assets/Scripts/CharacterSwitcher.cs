using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    int index = 0;
    [SerializeField] List<GameObject> players = new List<GameObject>();
    PlayerInputManager manager;

    // Start is called before the first frame update
    private void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        index += 1;
    }

    public void SwitchNextSpawnCharacter(PlayerInput input)
    {
        manager.playerPrefab = players[index % players.Count];
        index += 1;
    }
}
