using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour
{

    public float Damage = 1000000;

    void OnTriggerEnter2D(Collider2D other)
    {

     

        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            player.TakeDamage(Damage);

        }



    }
}
