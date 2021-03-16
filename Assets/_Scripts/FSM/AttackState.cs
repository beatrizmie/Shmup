using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    SteerableBehaviour steerable;
    IShooter shooter;
    GameManager gm;

    public float shootDelay = 1.0f;
    private float _lastShootTimestamp = 0.0f;

    public void Start()
    {
        gm = GameManager.GetInstance();
    }

    public override void Awake()
    {
        base.Awake();

        Transition ToPatrolForWaypoints = new Transition();
        ToPatrolForWaypoints.condition = new ConditionDistGT(transform,
            GameObject.FindWithTag("Player").transform,
            3.0f);
        ToPatrolForWaypoints.target = GetComponent<PatrolForWaypointsState>();

        // Adicionamos a transição em nossa lista de transições
        transitions.Add(ToPatrolForWaypoints);

        steerable = GetComponent<SteerableBehaviour>();
        shooter = steerable as IShooter;

        if (shooter == null)
        {
            throw new MissingComponentException("Este GameObject não implementa IShooter");
        }
    }

    public override void Update()
    {
        //TODO: Movimentação quando atacando

        if (gm.gameState != GameManager.GameState.GAME) return;

        if (Time.time - _lastShootTimestamp < shootDelay) return;

        _lastShootTimestamp = Time.time;
        shooter.Shoot();
    }
}
