using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : IEZombieStates
{
    private AiZombie _enemy;

    private float _idleTimer;
    //private float _idleDuration = 4;

    public void Enter(AiZombie enemy)
    {
        this._enemy = enemy;
    }

    public void Execute()
    {
        //idle
        Idle();


        if (_enemy.Target != null)
        {
            _enemy.ChangeState(new ZombiePatrolState());
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
        _enemy.MyAnimator.SetFloat("speed", 0);
        _idleTimer += Time.deltaTime;

        if (_idleTimer >= _enemy.IdleDuration)
        {
            _enemy.ChangeState(new ZombiePatrolState());
        }


    }
}
