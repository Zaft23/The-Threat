using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierPatrolState : IESoldierStates
{
    private AiSoldier _enemy;

    private float _patrolTimer;
    //private float _patrolDuration = 10;


    public void Enter(AiSoldier enemy)
    {
        this._enemy = enemy;
    }

    public void Execute()
    {
        Patrol();
        _enemy.MovePatrol();

        if (_enemy.Target != null)
        {
            _enemy.ChangeState(new SoldierShootState());
        }

    }

    public void Exit()
    {

    }

    public void OntriggerEnter(Collider2D other)
    {
        if(other.tag == "PatrolWayPoint")
        {
            //Debug.Log("fuck you");
            _enemy.ChangeDirection();
        }

        if (other.CompareTag("Bullet"))
        {
            Debug.Log("out of range!!");
            _enemy.Target = GameObject.Find("Player");
        }


    }

    private void Patrol()
    {
        //access component of enemy
        //enemy.*something


        _patrolTimer += Time.deltaTime;

        if (_patrolTimer >= _enemy.PatrolDuration)
        {
            _enemy.ChangeState(new SoldierIdleState());
        }



    }






}
