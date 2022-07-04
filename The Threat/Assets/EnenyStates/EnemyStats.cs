using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public bool IsBoss;
    public float EnemyHealth;
    [SerializeField]
    public float _enemyMaxHealth;
    //public float EnemyDamage;
    public float SecondStageHealth;
    private float _currentHealth;
    private AiSniperBoss SniperBoss;
    //
    public bool CanMove;

    private float force = 0.5f;

    public float enemyXp;
    public GameObject Blood;


    //public float XpMultiplier;
    //public float Dunno;

    public GameObject _player;
    public LevelSystem _playerLevel;
    public Player playerS;
    public float RandomPercent;

    public GameObject Supply;
    public bool DropWeapon;
    public GameObject Ak47;
    public GameObject M4A1;
    public GameObject BerettaM9;
    public GameObject Uzi;
    public GameObject PumpShotgun;
    public GameObject AutoShotgun;
    public GameObject HuntingRifle;
    public GameObject FiftyCalSniper;
    //public GameObject 


    // Start is called before the first frame update
    void Start()
    {

        _enemyMaxHealth = EnemyHealth;
        CanMove = false;

         _player = GameObject.FindGameObjectWithTag("Player");
         _playerLevel = _player.GetComponent<LevelSystem>();
         playerS = _player.GetComponent<Player>();
        //enemyXp = Mathf.Round(Dunno * 6 * XpMultiplier);






        //CurrentSuppressionHealth = SuppressionHealth;
    }

    [SerializeField]
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {


    

        if(_player.activeInHierarchy == false)
        {
            EnemyHealth = _enemyMaxHealth;
        }

        if(IsBoss && _player.activeInHierarchy == false)
        {
            //transform.position == FirstPos
        }



        if(playerS.Health == 0)
        {
            EnemyHealth = _enemyMaxHealth;
        }

        


        if (IsBoss == true)
        {
            timer += Time.deltaTime;
            if (timer >= 40f)
            {
                //_canHeal = true; spawn shit

                DropSupply();

                GameObject ammo = Instantiate(Supply, transform.position, Quaternion.identity);
                ammo.GetComponent<Rigidbody2D>().velocity = transform.position * force;

                GameObject ammo2 = Instantiate(Supply, transform.position, Quaternion.identity);
                ammo2.GetComponent<Rigidbody2D>().velocity = transform.position * force;

                GameObject ammo3 = Instantiate(Supply, transform.position, Quaternion.identity); 
                ammo3.GetComponent<Rigidbody2D>().velocity = transform.position * force;

                timer = 0;
            }

        }

    }


    public void TakeDamage(float Damage)
    {

            EnemyHealth -= Damage;
            _currentHealth = EnemyHealth;
            //do animation

            if(EnemyHealth <= 1)
            {
            DropSupply();
            }

            if (EnemyHealth <= 0)
            {
                //DropSupply();
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


    public void DropSupply()
    {
        RandomPercent = Random.Range(0, 100);
        GameObject gun;

        GameObject ammo = Instantiate(Supply, transform.position, Quaternion.identity);
        //ammo.GetComponent<Rigidbody2D>().velocity = transform.position * force;

 
            if (RandomPercent >= 0 && RandomPercent <= 5)
            {
                gun = Instantiate(FiftyCalSniper, transform.position, Quaternion.identity);
                //gun.GetComponent<Rigidbody2D>().velocity = transform.position * force;
                DropWeapon = false;
            }
            else if (RandomPercent >= 6 && RandomPercent <= 20)
            {
                gun = Instantiate(Ak47, transform.position, Quaternion.identity);
                //gun.GetComponent<Rigidbody2D>().velocity = transform.position * force;
                DropWeapon = false;
            }
            else if (RandomPercent >= 21 && RandomPercent <= 30)
            {
                gun = Instantiate(AutoShotgun, transform.position, Quaternion.identity);
                //gun.GetComponent<Rigidbody2D>().velocity = transform.position * force;
                DropWeapon = false;
            }
            else if (RandomPercent >= 31 && RandomPercent <= 50)
            {
                gun = Instantiate(BerettaM9, transform.position, Quaternion.identity);
                //gun.GetComponent<Rigidbody2D>().velocity = transform.position * force;
                DropWeapon = false;
            }
            else if (RandomPercent >= 51 && RandomPercent <= 60)
            {
                gun = Instantiate(HuntingRifle, transform.position, Quaternion.identity);
                //gun.GetComponent<Rigidbody2D>().velocity = transform.position * force;
                DropWeapon = false;

            }
            else if (RandomPercent >= 61 && RandomPercent <= 75)
            {
                gun = Instantiate(M4A1, transform.position, Quaternion.identity);
            //gun.GetComponent<Rigidbody2D>().velocity = transform.position;
                DropWeapon = false;

            }
            else if (RandomPercent >= 76 && RandomPercent <= 90)
            {
                gun = Instantiate(PumpShotgun, transform.position, Quaternion.identity);
            //gun.GetComponent<Rigidbody2D>().velocity = transform.position;
                DropWeapon = false;

            }
            else if (RandomPercent >= 91 && RandomPercent <= 100)
            {
                gun = Instantiate(Uzi, transform.position, Quaternion.identity);
            //gun.GetComponent<Rigidbody2D>().velocity = transform.position;
                DropWeapon = false;

            }

        
        else
        {
            Debug.Log("Enemy does not drop weapon");
        }
        



        

        //GameObject ammo2 = Instantiate(Supply, transform.position, Quaternion.identity);
        //ammo2.GetComponent<Rigidbody2D>().velocity = transform.position * force;

        //GameObject ammo3 = Instantiate(Supply, transform.position, Quaternion.identity); 
        //ammo3.GetComponent<Rigidbody2D>().velocity = transform.position * force;
    }


    void Die()
    {
        //DropSupply();
        

        GameObject blood= Instantiate(Blood, transform.position, Quaternion.identity);
        Destroy(blood, 5f);

        _playerLevel.GainExperienceScalable(enemyXp, 1);
        Destroy(gameObject);
    }

}
