using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referências imagem nave do inimigo: https://drive.google.com/file/d/1KfNJ8N7KZc7q4e0E3iOuNBTV_q1jgvMJ/view?usp=sharing

public class VolantBehaviour : SteerableBehaviour, IDamageable
{
    float angle = 0;
    GameManager gm;

    public void Start()
    {
        gm = GameManager.GetInstance();
    }

    private void FixedUpdate()
    {
        if (gm.gameState == GameManager.GameState.MENU)
        {
            transform.position = new Vector3(-5, 0, 0);
        }

        if (gm.gameState != GameManager.GameState.GAME) return;

        angle += 0.1f;
        if (angle > 2.0f * Mathf.PI) angle = 0.0f;

        Thrust(0, Mathf.Cos(angle));
    }

    public void TakeDamage()
    {
        gm.points += 150;
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
