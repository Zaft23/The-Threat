using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBossIdleState : IESniperBossStates
{
    private AiSniperBoss _enemy;
    private EnemyStats _stats;
    private float _idleTimer;
    private float _idleDuration = 4;

    public void Enter(AiSniperBoss enemy)
    {

        this._enemy = enemy;
        //this._stats = stats;
    }

    public void Execute()
    {
        Idle();
    }

    public void Exit()
    {



    }

    public void OntriggerEnter(Collider2D other)
    {



    }


    private void Idle()
    {
        //access component of enemy
        //enemy.*something


        _idleTimer += Time.deltaTime;

        if (_idleTimer >= _idleDuration)
        {
            _enemy.ChangeState(new SniperBossMoveState());
        }


    }

}
