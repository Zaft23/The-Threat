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
            _enemy.GroundCheck1 = other.gameObject;

        }
        if (other.tag == "Ground")
        {
            _enemy.GroundCheck2 = other.gameObject;

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            _enemy.GroundCheck1 = null;
        }
        if (other.tag == "Ground")
        {
            _enemy.GroundCheck2 = null;
        }

    }
}
