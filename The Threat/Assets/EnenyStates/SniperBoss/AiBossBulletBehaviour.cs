using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBossBulletBehaviour : MonoBehaviour
{

    public Weapon Weapon;
    public GameObject Impact;
    private float _BulletDestroy = 5f;
    public float BulletSpeed;
    //public float 
    private Transform player;

    Player _target;
    Vector2 _moveDirection;

    public float Damage;

    //private AiSoldier _soldier;
    private Rigidbody2D _rb2D;


    void start()
    {
        //var player = GameObject.FindGameObjectWithTag("Player").transform;
        //var target = new Vector2(player.position.x, player.position.y);

        //_rb2D = GetComponent<Rigidbody2D>();
        //    _target = GameObject.FindObjectOfType<Player>();
        //    _moveDirection = (_target.transform.position - transform.position).normalized* BulletSpeed;
        //_rb2D.velocity = new Vector2(_moveDirection.x, _moveDirection.y);
        ////https://www.youtube.com/watch?v=kOzhE3_P2Mk&ab_channel=AlexanderZotov

        //StartCoroutine(DestroyBullet());

        
    }

    private void Update()
    {
        Physics2D.IgnoreLayerCollision(6, 12);

        _rb2D = GetComponent<Rigidbody2D>();
        _target = GameObject.FindObjectOfType<Player>();
        _moveDirection = (_target.transform.position - transform.position).normalized * BulletSpeed;
        _rb2D.velocity = new Vector2(_moveDirection.x, _moveDirection.y);
        //https://www.youtube.com/watch?v=kOzhE3_P2Mk&ab_channel=AlexanderZotov

        StartCoroutine(DestroyBullet());
        var player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }
        if (collision.gameObject.tag == "Sight")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject effect = Instantiate(Impact, transform.position, Quaternion.identity);
        Destroy(effect, 5f);


        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            player.TakeDamage(Damage);

        }
        Destroy(gameObject);
        //Destroy(effect,5f);


    }


    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(_BulletDestroy);
        //_trailRenderer.emitting = false;
        Destroy(gameObject);


    }
}
