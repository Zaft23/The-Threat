using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthTest : MonoBehaviour
{

    public float Health;
    private float _currentHealth;
    //public Weapon PlayersWeapon;

    //public death effect

    void Start()
    {
        _currentHealth = Health;

        //var PDamage = PlayersWeapon.Damage;
    }

    public void TakeDamage (float Damage)
    {

        _currentHealth -= Damage;

        //do animation

        if (_currentHealth <= 0)
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
