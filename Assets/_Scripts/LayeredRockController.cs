using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayeredRockController : SteerableBehaviour, IDamageable
{
    GameManager gm;

    public void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void TakeDamage()
    {
        gm.points += 100;
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
