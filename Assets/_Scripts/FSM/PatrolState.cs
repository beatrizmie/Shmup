using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    SteerableBehaviour steerable;
    GameManager gm;

    float angle = 0;

    public void Start()
    {
        gm = GameManager.GetInstance();
    }
    
    public override void Awake()
    {
        base.Awake();

        // Criamos e populamos uma nova transição
        Transition ToAttack = new Transition();
        ToAttack.condition = new ConditionDistLT(transform,
            GameObject.FindWithTag("Player").transform,
            2.0f);
        ToAttack.target = GetComponent<AttackState>();

        // Adicionamos a transição em nossa lista de transições
        transitions.Add(ToAttack);

        steerable = GetComponent<SteerableBehaviour>();
    }

    public override void Update()
    {
        if (gm.gameState != GameManager.GameState.GAME) return;

        angle += 0.1f * Time.deltaTime;
        Mathf.Clamp(angle, 0.0f, 2.0f * Mathf.PI);
        float x = Mathf.Sin(angle);
        float y = Mathf.Cos(angle);

        steerable.Thrust(x, y);
    }
}
