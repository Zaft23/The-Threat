using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierIdleState : IESoldierStates
{

    private AiSoldier _enemy;

    private float _idleTimer;
    private float _idleDuration = 4;

    public void Enter(AiSoldier enemy)
    {
        this._enemy = enemy;
    }

    public void Execute()
    {
        //idle
        Idle();


        if(_enemy.Target != null)
        {
            _enemy.ChangeState(new SoldierPatrolState());
        }

    }

    public void Exit()
    {
        
    }

    public void OntriggerEnter(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("out of range!!");
            _enemy.Target = GameObject.Find("Player");
        }



    }

    private void Idle()
    {
        //access component of enemy
        //enemy.*something


        _idleTimer += Time.deltaTime;

        if(_idleTimer >= _idleDuration)
        {
            _enemy.ChangeState(new SoldierPatrolState());
        }


    }



}
