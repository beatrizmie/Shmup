using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Referências
// Imagem do asteroide: https://opengameart.org/content/a-layered-asteroid-rock
// Imagem da nave do jogador: https://drive.google.com/file/d/1gxtkMODjn94PMMMN0tms3OVepCzhZ2i5/view?usp=sharing

public class PlayerController : SteerableBehaviour, IShooter, IDamageable
{
    Animator animator;
    GameManager gm;

    public GameObject shot;
    public GameObject player;
    public Transform weapon;
    public AudioClip shootSFX;

    public float shootDelay = 0.5f;
    public float _lastShootTimestamp = 0.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        gm = GameManager.GetInstance();
    }

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;

        AudioManager.PlaySFX(shootSFX);

        _lastShootTimestamp = Time.time;
        Instantiate(shot, weapon.position + new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
    }

    public void TakeDamage()
    {
        gm.lives--;
        if (gm.lives <= 0)
        {
            if (gm.gameState == GameManager.GameState.GAME)
            {
                gm.ChangeState(GameManager.GameState.ENDGAME);
            }
            Die();
        }
    }

    public void Die()
    {
        // Destroy(gameObject);
        gm.ChangeState(GameManager.GameState.MENU);
    }

    private void FixedUpdate()
    {
        if (gm.gameState == GameManager.GameState.MENU)
        {
            transform.position = new Vector3(-5, 0, 0);
        }

        if (gm.gameState != GameManager.GameState.GAME) return;

        float yInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        Thrust(xInput, yInput);

        if (yInput != 0 || xInput != 0)
        {
           animator.SetFloat("Velocity", 1.0f);
        }
        else
        {
           animator.SetFloat("Velocity", 0.0f);
        }

        if (Input.GetAxisRaw("Jump") != 0)
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
}
