using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Weapon Weapon;
    private float _BulletDestroy = 5f;

    private void Start()
    {

        StartCoroutine(DestroyBullet());


    }

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

    //function it hit walls or some shit

    //function if bullet don't hit anything
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(_BulletDestroy);
        //_trailRenderer.emitting = false;
        Destroy(gameObject);


    }




}
