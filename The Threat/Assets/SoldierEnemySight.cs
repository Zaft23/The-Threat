using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierEnemySight : MonoBehaviour
{
    [SerializeField]
    private AiSoldier _enemy;



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _enemy.Target = other.gameObject;

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _enemy.Target = null;
        }

    }

}
