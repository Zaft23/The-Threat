using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbbasRushState : IEAbbasBossStates
{
    private AiAbbasBoss _enemy;

    private float _attackTimer;
    //private float _attackDuration = 10f;

    public void Enter(AiAbbasBoss enemy)
    {
        this._enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("RushState");
        _enemy.RushMove();
        _enemy.RushMelee();
        AttackDuration();
    }

    public void Exit()
    {
       

    }

    public void OntriggerEnter(Collider2D other)
    {
        if (other.tag == "PatrolWayPoint")
        {
            //Debug.Log("fuck you");
            _enemy.ChangeDirection();
        }

      //  if (other.CompareTag("Bullet"))
      //  {
      //      Debug.Log("out of range!!");
      //      _enemy.Target = GameObject.Find("Player");
      //  }

    }

    private void AttackDuration()
    {
        //engagement duration
        //enemy.*something


        _attackTimer += Time.deltaTime;

        if (_attackTimer >= _enemy.RushDuration)
        {
            _enemy.ChangeState(new AbbasIdleState());
        }


    }
}
