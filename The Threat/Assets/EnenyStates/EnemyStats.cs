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

    public float enemyXp;

    public float XpMultiplier;
    public float Dunno;

    public GameObject _player;
    public LevelSystem _playerLevel;



    // Start is called before the first frame update
    void Start()
    {
        CanMove = false;

         _player = GameObject.FindGameObjectWithTag("Player");
         _playerLevel = _player.GetComponent<LevelSystem>();

        //enemyXp = Mathf.Round(Dunno * 6 * XpMultiplier);






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

    void OnUpgradeMenuToggle(bool active)
    {
//GetComponent<>
    }





    void Die()
    {
        //Instantiate()
        _playerLevel.GainExperienceScalable(enemyXp, 1);
        Destroy(gameObject);
    }

}
