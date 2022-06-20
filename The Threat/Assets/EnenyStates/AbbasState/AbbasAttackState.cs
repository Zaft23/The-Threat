using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbbasAttackState : IEAbbasBossStates
{
    private AiAbbasBoss _enemy;

    //can be modify from AiAbbas 
    private float _attackTimer;
    //private float _attackDuration = 5;

    public void Enter(AiAbbasBoss enemy)
    {
        this._enemy = enemy;
    }

    public void Execute()
    {

        
        if (_enemy.Target != null)
        {
            Debug.Log("Normal Attack");
            // Debug.Log("ATAAAACK");
            _enemy.LookAtTarget();
            _enemy.AiChase();
            _enemy.AiMelee();


        }

        //else
        //{
        //    _enemy.ChangeState(new AbbasIdleState());
        //}

        AttackDuration();
    }

    public void Exit()
    {
        
    }

    public void OntriggerEnter(Collider2D other)
    {
        
    }

    private void AttackDuration()
    {
        //engagement duration
        //enemy.*something


        _attackTimer += Time.deltaTime;

        if (_attackTimer >= _enemy.AttackDuration)
        {
            _enemy.ChangeState(new AbbasRushState());
        }


    }


}
