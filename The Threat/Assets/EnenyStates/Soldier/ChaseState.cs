using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : IESoldierStates
{
    //float targetRange = 5f;

    private AiSoldier _enemy;

    public void Enter(AiSoldier enemy)
    {
        this._enemy = enemy;
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {

    }

    public void OntriggerEnter(Collider2D other)
    {

    }
}
