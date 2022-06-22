using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBossAttackState : IESniperBossStates
{
    private AiSniperBoss _enemy;
    private EnemyStats _stats;

    private float _engageTimer;
    //private float _engageDuration = 4;
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
        //Debug.Log("Can't Take Damage");

        _enemy.CanTakeDamage = false;
        _enemy.CanTakeSupression = true;
        _enemy.CanAttack = true;

        //_enemy.CurrentSuppressionHealth = _enemy.SuppressionHealth;
        if (_enemy.Target != null && _enemy.CanAttack == true)
        {
            //_enemy.MyAnimator.SetFloat("speed", 0);
            //_enemy.CanShoot = true;
            //Debug.Log("AI shooting");
    
             _enemy.AiShoot();
            //EngageDuration();

            //REngageDuration();
            
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


    //private void EngageDuration()
    //{
    //    //access component of enemy
    //    //enemy.*something
    //    Debug.Log("i'm walkin' here");

    //    _engageTimer += Time.deltaTime;
    //    if(_enemy.CanShoot == true)
    //    {
    //        if (_engageTimer >= _engageDuration)
    //        {
    //            //_enemy.CanShoot = false;
    //            _enemy.MyAnimator.SetBool("isAttacking", false);
    //            _enemy.MyAnimator.SetBool("isAttacking2", false);
    //            _enemy.CanShoot = false;
    //        }
    //    }
        


    //}
    //private void REngageDuration()
    //{
    //    //access component of enemy
    //    //enemy.*something
    //    Debug.Log("i'm walkin' here");

    //    _engageTimer += Time.deltaTime;

    //    if(_enemy.CanShoot == false)
    //    {
    //        if (_engageTimer >= _engageDuration)
    //        {
    //            //_enemy.CanShoot = false;
    //            _enemy.CanShoot = true;
    //        }
    //    }

    //}
}
