using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSoldier : MonoBehaviour
{
    //private float _lastShootTime;

    public Weapon Weapon;

    //public float EnemyHealth;
    //private float _currentHealth;
    //public float Damage;
    public float MoveSpeed;
    public float ChaseSpeed;
    public float ChaseSpeedR;
    public float FiringTime;
    public float ReloadingTime;

    //stoping distance
    public float ShootingRange;
    public float RetreatDistance;




    public Transform ShootPos;
    public Transform FirePoint;
    public Vector3 Direction ;



    public GameObject Gun;

    public float RateOfFire;
    public float ShootingTime;
    public float StartShootingTime;
    public float EngagementTime;
    public float StartEngagementTime;

    public GameObject Bullet;
    

    public bool Attack { get; set; }
    private bool _facingRight;

    public float BulletSpeed;

    //public Animator Animator;
    private Rigidbody2D Rb2d;
    public GameObject Target;
    public GameObject GroundCheck;

    [SerializeField]
    private bool _canShoot;


    private IESoldierStates _currentState;







    private void Awake()
    {
        
        //_state = State.Patrol;
        //_state = State.Patrol;
        Rb2d = GetComponent<Rigidbody2D>();
    }



    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        //_currentHealth = EnemyHealth;
        _facingRight = true;
        ShootingTime = StartShootingTime;
        ChangeState(new SoldierIdleState());
        _canShoot = true;
    }



    // Update is called once per frame
    void Update()
    {
        
        //ignore collision


        _currentState.Execute();
        LookAtTarget();

        if (GroundCheck == null)
        {


            ChaseSpeed = 0;

        }

        if (ChaseSpeed == 0 && Target == null)
        {
            StartCoroutine(ResetChaseSpeed());
            
            Debug.Log("target dissapear");
        }

        if(_canShoot == false)
        {
            StartCoroutine(ResetShootingTime());
        }
        


    }



    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if (xDir < 0 && _facingRight || xDir > 0 && !_facingRight)
            {
                ChangeDirection();

            }

        }

    }

    public void MovePatrol()
    {

        transform.Translate(GetDirection() * (MoveSpeed * Time.deltaTime));

    }


    public Vector2 GetDirection()
    {
        return _facingRight ? Vector2.right : Vector2.left;
    }

    public void ChangeDirection()
    {
        _facingRight = !_facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }



    public void ChangeState(IESoldierStates newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;
        _currentState.Enter(this);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _currentState.OntriggerEnter(other);
    }



    public void AiShoot()
    {

        var Player = GameObject.FindGameObjectWithTag("Player").transform;

         
            //Behaviour
            //if withing line of sight 
            // do function
            //if enemy too far away to shoot
            if (Vector2.Distance(transform.position, Player.position) > ShootingRange)
            {
                Debug.Log("too far");
                transform.position = Vector2.MoveTowards(transform.position, Player.position, ChaseSpeed * Time.deltaTime);
            }
            //if enemy in range to engage player
            else if (Vector2.Distance(transform.position, Player.position) < ShootingRange &&
                Vector2.Distance(transform.position, Player.position) > RetreatDistance)
            {


                Debug.Log("engage");
                transform.position = this.transform.position;
            }


            //if enemy too close to player
            else if (Vector2.Distance(transform.position, Player.position) < RetreatDistance)
            {
                Debug.Log("too close");
                transform.position = Vector2.MoveTowards(transform.position, Player.position, -ChaseSpeed * Time.deltaTime);
            }


            if(_canShoot == true)
            {
                if (ShootingTime <= 0)
                {

                    GameObject bullet = Instantiate(Bullet, FirePoint.position, Quaternion.identity);

                    ShootingTime = RateOfFire;

                    StartCoroutine(BooleanShootingTime());

                }
                else
                {
                    ShootingTime -= Time.deltaTime;
                }
            }
  

        

        

    }

    //public void TakeDamage(float Damage)
    //{

    //    EnemyHealth -= Damage;

    //    //do animation

    //    if (EnemyHealth <= 0)
    //    {
    //        Debug.Log("enemy die");
    //        //do animation

    //        if (_currentHealth <= 0)
    //        {

    //            Die();
    //        }
            
    //    }

    //}

    //void Die()
    //{
    //    //Instantiate()
    //    Destroy(gameObject);
    //}

    public void Stop()
    {
        transform.position = this.transform.position;
    }


    public Vector2 GetPosition()
    {
       return transform.position;
    }

    private IEnumerator ResetChaseSpeed()
    {
        yield return new WaitForSeconds(7);
        ChaseSpeed = ChaseSpeedR;
        //ChangeDirection();

    }

    private IEnumerator BooleanShootingTime()
    {
        yield return new WaitForSeconds(FiringTime);

        _canShoot = false;
        //ChangeDirection();

    }

    private IEnumerator ResetShootingTime()
    {
        yield return new WaitForSeconds(ReloadingTime);

        _canShoot = true;

    }








}