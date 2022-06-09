using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IESoldierStates 
{
    void Execute();
    void Enter(AiSoldier enemy);
    void Exit();
    void OntriggerEnter(Collider2D other);




}
