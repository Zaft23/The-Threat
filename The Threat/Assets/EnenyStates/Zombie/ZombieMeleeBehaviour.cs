using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMeleeBehaviour : MonoBehaviour
{
    [SerializeField]
    private AiZombie _enemy;
    //public BoxCollider2D myCollider;


    //private void Start()
    //{
    //    //myCollider = GetComponent<BoxCollider2D>();
    //}


    //private void Update()
    //{
    //    if (_enemy.CanAttack == false)
    //    {
    //        _enemy.AiAttack();
    //        //myCollider.enabled = true;
    //    }
    //}

    private void OnCollisionStay2D(Collision2D other)
    {
        //collision.gameObject.name.Equals("Player")

        if (_enemy.CanAttack == true)
        {
            if (other.gameObject.tag == "Player")
            {
                _enemy.AiAttack();
                //another if statement

                Debug.Log("Helooooooooooooooo");
                other.gameObject.GetComponent<Player>().TakeDamage(_enemy.Damage);
                //var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
                //player.TakeDamage(_enemy.Damage);
                //_enemy.CanGiveDamage = false;
                //myCollider.enabled = false;
                _enemy.CanAttack = false;
                //_enemy.MAttack.enabled = false;
            }
        }


    }


}




