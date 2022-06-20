using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBossSight : MonoBehaviour
{
    [SerializeField]
    private AiSniperBoss _enemy;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _enemy.Target = other.gameObject;

        }

    }

    //private void OnCollisionStay2D(Collision2D other)
    //{
    //        if (other.gameObject.tag == "Player")
    //        {
    //            _enemy.Target = other.gameObject;

    //        }

    //}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _enemy.Target = null;
        }

    }

}
