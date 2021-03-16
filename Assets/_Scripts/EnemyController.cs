using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SteerableBehaviour, IShooter, IDamageable
{
    public GameObject shot;
    GameManager gm;

    public void Start()
    {
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }

    public void TakeDamage()
    {
        gm.points += 300;
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
