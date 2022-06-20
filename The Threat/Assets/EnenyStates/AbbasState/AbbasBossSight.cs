using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbbasBossSight : MonoBehaviour
{
    [SerializeField]
    private AiAbbasBoss _enemy;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _enemy.Target = other.gameObject;

        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _enemy.Target = null;
        }

    }
}
