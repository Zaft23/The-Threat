using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBossMoveState : IESniperBossStates
{
    private AiSniperBoss _enemy;
    private EnemyStats _stats;
    //private float _ShootTimer;
    //private float _ShootCoolDown;
    // private float _shootingRange = 5f;

    //private bool _canShoot;



    public void Enter(AiSniperBoss enemy)
    {
        this._enemy = enemy;
       //this._stats = stats;
    }

    public void Execute()
    {
        _enemy.CanTakeDamage = true;
        _enemy.CanTakeSupression = false;
        //if (_enemy.ChangeNumber == true)
        //{
        //_enemy.RandomNumber();
        //_enemy.ChangeNumber = false;
        //}
        //_enemy.CanTakeDamage = true;
        //if (_enemy.transform.position != _enemy.Waypoints[_enemy.WaypointIndex].transform.position)
        //{
            _enemy.MoveToCover();
        //if (_enemy.transform.position == _enemy.Waypoints[_enemy.WaypointIndex].transform.position)
        //{
        //    _enemy.ChangeNumber = false;
        //    _enemy.ChangeState(new SniperBossAttackState());
        //}
        //}

        //_enemy.ChangeNumber = true;


        //if (_enemy.transform.position == _enemy.Waypoints[_enemy.WaypointIndex].transform.position)
        //{
        // _enemy.WaypointIndex = _enemy.RandomWayPoint;
        //_enemy.ChangeNumber = true;
        //}



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
    //    if (other.tag == "PatrolWayPoint" )
    //    {
    //        //_enemy.CanTakeDamage = true;
    //        //_enemy.CanTakeSupression = false;
    //        if (_enemy.transform.position == _enemy.Waypoints[_enemy.WaypointIndex].transform.position)
    //        {
    //            Debug.Log("ayyyyyyyyyyyyyyyy");
    //            //_enemy.ChangeNumber = false;
    //            //_enemy.CanShoot = true;
    //            _enemy.ChangeState(new SniperBossAttackState());
    //        }

    //    }

        //if (other.CompareTag("Bullet"))
        //{
        //    Debug.Log("out of range!!");
        //    _enemy.Target = GameObject.Find("Player");
        //}

    }
}
