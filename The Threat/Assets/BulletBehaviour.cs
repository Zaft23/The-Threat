using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Weapon Weapon;

    void OnTriggerEnter2D(Collider2D collision)
    {

        
        //effect
        //GameObject bullet = Weapon.BulletPrefab;
        
        var enemy = collision.GetComponent<EnemyHealthTest>();
        if (enemy != null)
        {
            enemy.TakeDamage(Weapon.Damage);
            
        }

        Destroy(gameObject);
        //Destroy(effect,5f);
        

    }
}
