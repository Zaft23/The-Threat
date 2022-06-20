using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackState : IEZombieStates
{
    private AiZombie _enemy;

    public void Enter(AiZombie enemy)
    {
        this._enemy = enemy;
    }

    public void Execute()
    {
        if (_enemy.Target != null)
        {
           // Debug.Log("ATAAAACK");
            _enemy.AiChase();
            _enemy.AiMelee();


        }

        else
        {
            _enemy.ChangeState(new ZombieIdleState());
        }


    }

    public void Exit()
    {

    }

    public void OntriggerEnter(Collider2D other)
    {
        
    }

    



}