using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IESniperBossStates
{
    void Execute();
    void Enter(AiSniperBoss enemy);
    void Exit();
    void OntriggerEnter(Collider2D other);




}
