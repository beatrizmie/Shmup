using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayeredRockSpawner : MonoBehaviour
{
    public GameObject layeredRock;

    GameManager gm;

    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += SpawnLayeredRock;
        SpawnLayeredRock();
    }

    void SpawnLayeredRock()
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {
            for(int i = 0; i < 15; i++)
            {
                for (int j = -4; j <= 5; j += 2)
                {
                    Vector3 posicao = new Vector3(3*i, j, 0);
                    Instantiate(layeredRock, posicao, Quaternion.identity, transform);
                }
            }
        }
    }

    void Update()
    {
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME)
        {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }  
    }
}
