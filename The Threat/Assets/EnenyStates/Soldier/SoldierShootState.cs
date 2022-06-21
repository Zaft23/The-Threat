using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierShootState : IESoldierStates
{
    private AiSoldier _enemy;




    public void Enter(AiSoldier enemy)
    {
        this._enemy = enemy;
    }

    public void Execute()
    {
        //AiShoot();

        if(_enemy.Target != null)
        {
            Debug.Log("AI shooting");
            _enemy.AiShoot();

           

        }

        else
        {
            //_enemy.ChangeState(new SoldierIdleState());
            _enemy.ChangeState(new SoldierPatrolState());
        }
        



    }

    public void Exit()
    {

    }

    public void OntriggerEnter(Collider2D other)
    {

    }

   





    

    


}
