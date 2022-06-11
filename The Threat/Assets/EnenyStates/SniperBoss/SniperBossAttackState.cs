using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBossAttackState : IESniperBossStates
{
    private AiSniperBoss _enemy;

    private float _engageTimer;
    private float _engageDuration = 4;
    //private float _ShootTimer;
    //private float _ShootCoolDown;
    // private float _shootingRange = 5f;

    //private bool _canShoot;



    public void Enter(AiSniperBoss enemy)
    {
        this._enemy = enemy;
    }

    public void Execute()
    {
        

        if (_enemy.Target != null)
        {
            //_enemy.CanShoot = true;
            Debug.Log("AI shooting");
            _enemy.AiShoot();
            EngageDuration();



        }

        
        //AiShoot();

        //if (_enemy.Target != null)
        //{
        //    Debug.Log("AI shooting");
        //    _enemy.AiShoot();

        //}

        //else
        //{
        //    _enemy.ChangeState(new SoldierIdleState());
        //}

    }

    public void Exit()
    {

    }

    public void OntriggerEnter(Collider2D other)
    {

    }


    private void EngageDuration()
    {
        //access component of enemy
        //enemy.*something
        Debug.Log("i'm walkin' here");

        _engageTimer += Time.deltaTime;

        if (_engageTimer >= _engageDuration)
        {
            //_enemy.CanShoot = false;
            _enemy.ChangeState(new SniperBossMoveState());
        }


    }
}
