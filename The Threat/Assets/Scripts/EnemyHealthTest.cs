using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthTest : MonoBehaviour
{

    public float Health;
    //public Weapon PlayersWeapon;

    //public death effect

    void Start()
    {
        //var PDamage = PlayersWeapon.Damage;
    }

    public void TakeDamage (float Damage)
    {

        Health -= Damage;

        if (Health <= 0)
        {
            Die();
        }

    }

    void Die()
    {
        //Instantiate()
        Destroy(gameObject);
    }



}
