using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    public float EnemyHealth;
    public float EnemyDamage;
    public float SecondStageHealth;

    private float _currentHealth;

    private AiSniperBoss SniperBoss;

    //

    
    public bool CanMove;


    // Start is called before the first frame update
    void Start()
    {
        
        CanMove = false;

        //CurrentSuppressionHealth = SuppressionHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(float Damage)
    {

            EnemyHealth -= Damage;
            _currentHealth = EnemyHealth;
            //do animation

            if (EnemyHealth <= 0)
            {
                Debug.Log("enemy die");
                //do animation

                if (_currentHealth <= 0)
                {

                    Die();
                }

            }
        
           

    }

    public void SniperTakeDamage(float Damage)
    {
        //if (SniperBoss.CanTakeDamage == true)
        //{
            EnemyHealth -= Damage;
            _currentHealth = EnemyHealth;
            //do animation

            if (EnemyHealth <= 0)
            {
                Debug.Log("enemy die");
                //do animation

                if (_currentHealth <= 0)
                {

                    Die();
                }

            }
        //}





    }







    void Die()
    {
        //Instantiate()
        Destroy(gameObject);
    }

}
