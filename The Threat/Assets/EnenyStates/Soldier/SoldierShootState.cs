using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierShootState : IESoldierStates
{
    private AiSoldier _enemy;

    //private float _ShootTimer;
    //private float _ShootCoolDown;
   // private float _shootingRange = 5f;

    //private bool _canShoot;
    


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
            _enemy.ChangeState(new SoldierIdleState());
        }
        



    }

    public void Exit()
    {

    }

    public void OntriggerEnter(Collider2D other)
    {

    }

   





    

    


}
