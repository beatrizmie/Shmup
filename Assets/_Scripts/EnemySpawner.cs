using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject purpleShip;
    public GameObject yellowEnemy;

    GameManager gm;

    float x;
    float y;

    void Start()
    {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Launch;
        Launch();
    }

    void Launch()
    {   
        DestroyAll();

        LaunchPurpleShip(3.0f, 22.0f);
        LaunchYellowEnemy(3.0f, 22.0f);
    }    

    private void LaunchPurpleShip(float x1, float x2)
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {
            for (int i=0; i<1; i++)
            {
                x = Random.Range(x1, x2);
                y = Random.Range(-4.0f, 4.0f);

                Instantiate(purpleShip, new Vector3(x,y), Quaternion.identity, transform);    
            }
        }
    }

    private void LaunchYellowEnemy(float x1, float x2)
    {
        if (gm.gameState == GameManager.GameState.GAME)
        {
            for (int i=0; i<1; i++)
            {
                x = Random.Range(x1, x2);
                y = Random.Range(-4.0f, 4.0f);

                Instantiate(yellowEnemy, new Vector3(x,y), Quaternion.identity, transform);    
            }
        }
    }

    private void DestroyAll()
    {
        foreach (Transform t in transform)
        {
            GameObject.Destroy(t.gameObject);
        }
    }

    private float PurpleShipSpawnTimestamp = 0.0f;
    private bool PurpleShipSpawned = true;


    private float YellowEnemySpawnTimestamp = 0.0f;
    private bool YellowEnemySpawned = true;

    Vector3 position;

    void Update()
    {
        
        if (Time.time - PurpleShipSpawnTimestamp > 1.0f) {
            
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            PurpleShipSpawnTimestamp = Time.time;

            if (PurpleShipSpawned) {
                PurpleShipSpawned = false;
                position = new Vector3(Random.Range(-2.0f, 5.0f), Random.Range(1.0f, 15.0f));
            } else {
                PurpleShipSpawned = true;
                position = new Vector3(Random.Range(-2.0f, 12.0f), Random.Range(1.0f, 15.0f));
            }
            
            playerPosition += position;
            Instantiate(purpleShip, playerPosition, Quaternion.identity, transform);
        }

        if (Time.time - YellowEnemySpawnTimestamp > 3.0f) {
            
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            YellowEnemySpawnTimestamp = Time.time;

            if (YellowEnemySpawned) {
                YellowEnemySpawned = false;
                position = new Vector3(Random.Range(-3.0f, 10.0f), Random.Range(-7.0f, 7.0f));
            } else {
                YellowEnemySpawned = true;
                position = new Vector3(Random.Range(-10.0f, -3.0f), Random.Range(-7.0f, 7.0f));
            }

            playerPosition += position;
            Instantiate(yellowEnemy, playerPosition, Quaternion.identity, transform);
        }
    }
}
