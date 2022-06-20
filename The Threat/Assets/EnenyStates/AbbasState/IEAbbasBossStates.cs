using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEAbbasBossStates 
{
    void Execute();
    void Enter(AiAbbasBoss enemy);
    void Exit();
    void OntriggerEnter(Collider2D other);
}
