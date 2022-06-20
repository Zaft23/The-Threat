using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbbasIdleState : IEAbbasBossStates
{
    private AiAbbasBoss _enemy;

    private float _idleTimer;
    //private float _idleDuration = 2f;

    public void Enter(AiAbbasBoss enemy)
    {
        this._enemy = enemy;
    }

    public void Execute()
    {
        //idle
        Idle();

        Debug.Log("Take a breath");
        //if (_enemy.Target != null)
        //{
            //_enemy.ChangeState(new AbbasAttackState());
        //

    }

    public void Exit()
    {

    }

    public void OntriggerEnter(Collider2D other)
    {
        //if (other.CompareTag("Bullet"))
        //{
        //    Debug.Log("out of range!!");
        //    _enemy.Target = GameObject.Find("Player");
        //}



    }

    private void Idle()
    {
        //access component of enemy
        //enemy.*something


        _idleTimer += Time.deltaTime;

        if (_idleTimer >= _enemy.IdleDuration)
        {
            _enemy.ChangeState(new AbbasAttackState());
        }


    }
}
