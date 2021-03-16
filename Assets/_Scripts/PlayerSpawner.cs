using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;

    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += SpawnPlayers;
        SpawnPlayers();
        
    }

    void SpawnPlayers()
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {
            Vector3 posicao = new Vector3(-5, 0, 0);
            Instantiate(player, posicao, Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
