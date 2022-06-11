using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBossMoveState : IESniperBossStates
{
    private AiSniperBoss _enemy;

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


        _enemy.MoveToCover();




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
        if (other.tag == "PatrolWayPoint")
        {

            Debug.Log("ayyyyyyyyyyyyyyyy");
            //_enemy.CanShoot = true;
            _enemy.ChangeState(new SniperBossAttackState());
        }

        //if (other.CompareTag("Bullet"))
        //{
        //    Debug.Log("out of range!!");
        //    _enemy.Target = GameObject.Find("Player");
        //}

    }
}
