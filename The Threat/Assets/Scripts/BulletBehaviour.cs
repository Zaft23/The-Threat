using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Weapon Weapon;
    private float _BulletDestroy = 5f;
    


    private void Awake()
    {
        
    }
    private void Start()
    {

        StartCoroutine(DestroyBullet());
        

    }

    void Update()
    {
        Physics2D.IgnoreLayerCollision(9, 10);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //effect
        //GameObject bullet = Weapon.BulletPrefab;
        

        //if (other.CompareTag("Sight"))
        //{

        //}

        if (other.CompareTag("Enemy"))
        {
            //need better logic than this
            var enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(Weapon.Damage);



        }
        Destroy(gameObject);
        //Destroy(effect,5f);


    }
    //void OnTriggerEnter2D(Collider2D other)
    //{

    //    var enemy = other.GetComponent<EnemyHealthTest>();
    //    //effect
    //    //GameObject bullet = Weapon.BulletPrefab;
    //    if (other.CompareTag("Enemy") && enemy != null)
    //    {
    //        enemy.TakeDamage(Weapon.Damage);

    //    }




    //    Destroy(gameObject);
    //    //Destroy(effect,5f);


    //}

    //function it hit walls or some shit

    //function if bullet don't hit anything
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(_BulletDestroy);
        //_trailRenderer.emitting = false;
        Destroy(gameObject);


    }




}
