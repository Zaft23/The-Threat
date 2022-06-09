using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    public float EnemyHealth;
    private float _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
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

    void Die()
    {
        //Instantiate()
        Destroy(gameObject);
    }

}
