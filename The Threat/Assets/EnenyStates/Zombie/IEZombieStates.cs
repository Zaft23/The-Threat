using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEZombieStates
{
    void Execute();
    void Enter(AiZombie enemy);
    void Exit();
    void OntriggerEnter(Collider2D other);




}

