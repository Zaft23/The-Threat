using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEdgeCheck : MonoBehaviour
{
    [SerializeField]
    private AiZombie _enemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            _enemy.GroundCheck = other.gameObject;

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            _enemy.GroundCheck = null;
        }

    }
}
