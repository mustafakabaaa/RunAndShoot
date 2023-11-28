using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private float seacrhTimer;
    public float moveTimer;
    public float maxSeacrhTime = 8f;
    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy.LastKnowPos);
        seacrhTimer = 0f;
    }

    

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
        //enemy.Agent.stoppingDistance 0.1f yerine kullanýlabilir.
        if (enemy.Agent.remainingDistance < 0.1f)
        {
            seacrhTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;
            if (moveTimer > Random.Range(3, 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                moveTimer = 0;
            }
            if (seacrhTimer > maxSeacrhTime)
            {
                stateMachine.ChangeState(new PetrolState());
            }
        }
    }
    public override void Exit()
    {

    }
}
