using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSniperBoss : MonoBehaviour
{
    public Weapon Weapon;
    public Player Player;

    public Animator MyAnimator;

    public EnemyStats EnemyStats;

    //
    public float SuppressionHealth;
    public float RSuppressionHealth;
    public float CurrentSuppressionHealth;
    public bool CanTakeDamage;
    public bool CanTakeSupression;
    public bool CanAttack;



    public float MoveSpeed;


    //stoping distance
    public float ShootingRange;

    public Transform ShootPos;
    public Transform FirePoint;
    public Vector3 Direction;

    public GameObject Gun;

    public float RateOfFire;
    public float EngagementTime;
    public float ReloadingTime;




    private float _ShootingTIme;
    private float _startShootingTIme;

    public GameObject Bullet;
    public GameObject Bullet2;


    public bool Attack { get; set; }
    private bool _facingRight;

    public float BulletSpeed;


    private Rigidbody2D Rb2d;
    public GameObject Target;
    public GameObject GroundCheck;

    //[SerializeField]
    public bool CanShoot;

    private IESniperBossStates _currentState;

    public Transform CurrentPosition;
    [SerializeField]
    public Transform[] Waypoints;
    [SerializeField]
    public int WaypointIndex;
    //public Transform WPintIndex;
    public int RandomWayPoint;
    public bool ChangeNumber;
    private int rand;

    private void Awake()
    {

        Rb2d = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
        //transform.position = _waypoints[rand].transform.position;
        //WPintIndex.transform.position = _waypoints[rand].transform.position;
        //rand = Random.Range(1, 3);
        RandomWayPoint = Random.Range(0, 3);
        
    }


    // Start is called before the first frame update
    void Start()
    {
        //spawn here/location

        Physics2D.IgnoreLayerCollision(6, 7);
        
        _facingRight = true;
        _ShootingTIme = _startShootingTIme;
        ChangeState(new SniperBossAttackState());
  
        CanTakeDamage = false;

        //
        CanShoot = true;
        

        //transform.position = _waypoints[rand.transform.position;
        //transform.position = _waypoints[1];
        transform.position = Waypoints[WaypointIndex].transform.position;
        //WPintIndex.transform.position = _waypoints[rand].transform.position;
        ChangeNumber = false;
        
        //
        RSuppressionHealth = SuppressionHealth;

        //
        EnemyStats = GetComponent<EnemyStats>();



}



    // Update is called once per frame
    void Update()
    {
        _currentState.Execute();
        LookAtTarget();

        if(ChangeNumber == true)
        {
            RandomWayPoint = Random.Range(0, 3);
        }
        
        if(SuppressionHealth == 0)
        {
            CanTakeSupression = false;
            //ChangeNumber = true;
        }


        if (CanShoot == false)
        {
            MyAnimator.SetBool("isAttacking", false);
            MyAnimator.SetBool("isAttacking2", false);
            MyAnimator.SetBool("isReloading", true);
            StartCoroutine(ResetShootingTime());
        }



        //move mod and rate of fire
        if (EnemyStats.EnemyHealth <= EnemyStats.SecondStageHealth)
        {

            Debug.Log("Second Stage");
            MoveSpeed = 10f;
            RateOfFire = 1f;
            
            //longer
            //EngagementTime = ;
            //faster
            //ReloadingTIme = ;

        }

        #region comment
        //was trying to check if you go to intended waypoint but fuck it
        //if (transform.position == Waypoints[WaypointIndex].transform.position)
        //{
        //ChangeNumber = false;
        //ChangeState(new SniperBossAttackState());
        //}

        //if(SuppressionHealth != 0)
        //ignore collision

        //if (GroundCheck == null)
        //{
        //    ChaseSpeed = 0;
        //}

        //if (ChaseSpeed == 0 && Target == null)
        //{
        //    StartCoroutine(ResetChaseSpeed());

        //    Debug.Log("target dissapear");
        //}


        #endregion

    }

    public void AiShoot1()
    {
        Debug.Log("amkiiiiiiiiiiiiiinh");
        GameObject bullet = Instantiate(Bullet, FirePoint.position, Quaternion.identity);

        _ShootingTIme = RateOfFire;

        //StartCoroutine(BooleanShootingTime());

    }

    public void AiShoot2()
    {
        Debug.Log("second Staaaaaaaaaaage");
        GameObject bullet = Instantiate(Bullet2, FirePoint.position, Quaternion.identity);

        _ShootingTIme = RateOfFire;

        //StartCoroutine(BooleanShootingTime());

    }

    //private float _engageTimer;
    //private void ReloadCountDown()
    //{
       
       
    //        _engageTimer += Time.deltaTime;

    //        if (_engageTimer >= EngagementTime)
    //        {
    //        MyAnimator.SetBool("isAttacking", false);
    //        MyAnimator.SetBool("isAttacking2", false);
    //        CanShoot = false;
    //        }
        
      
    //}
    //private void RShootinTime()
    //{

    //       _engageTimer += Time.deltaTime;

    //        if (_engageTimer >= EngagementTime)
    //        {
    //            //MyAnimator.SetBool("isAttacking", false);
    //            //MyAnimator.SetBool("isAttacking2", false);
    //             CanShoot = true;
    //        }
        
    //}

    public void AiShoot()
    {
        

        //var Player = GameObject.FindGameObjectWithTag("Player").transform;
        if (CanShoot == true)
        {
            //ReloadCountDown();
            if (EnemyStats.EnemyHealth > EnemyStats.SecondStageHealth )
            {
                Debug.Log("CanShoot");
               
                MyAnimator.SetBool("isAttacking", true);
                //MyAnimator.SetBool("isAttacking2", false);
                MyAnimator.SetFloat("speed", 0);
                MyAnimator.SetFloat("rateoffire", 1f);
                StartCoroutine(BooleanShootingTime());
                //ReloadCountDown();
            }
            else if(EnemyStats.EnemyHealth <= EnemyStats.SecondStageHealth)
            {
                
                //MyAnimator.SetBool("isAttacking", false);
                MyAnimator.SetBool("isAttacking2", true);
                MyAnimator.SetFloat("speed", 0);
                MyAnimator.SetFloat("rateoffire", 3f);
                StartCoroutine(BooleanShootingTime());
                //ReloadCountDown();
            }



        }

        #region Shoot not based on animation
        //if (CanShoot == true)
        //{
        //    MyAnimator.SetBool("isAttacking", true);
        //    MyAnimator.SetFloat("speed", 0);

        //    if (EnemyStats.EnemyHealth > EnemyStats.SecondStageHealth)
        //    {
        //        if (_ShootingTIme <= 0)
        //        {

        //            Debug.Log("amkiiiiiiiiiiiiiinh");
        //            GameObject bullet = Instantiate(Bullet, FirePoint.position, Quaternion.identity);

        //            _ShootingTIme = RateOfFire;

        //            StartCoroutine(BooleanShootingTime());

        //        }
        //        else
        //        {
        //            _ShootingTIme -= Time.deltaTime;
        //        }

        //    }
        //    else
        //    {

        //        if (_ShootingTIme <= 0)
        //        {
        //           Debug.Log("second Staaaaaaaaaaage");
        //           GameObject bullet = Instantiate(Bullet2, FirePoint.position, Quaternion.identity);

        //           _ShootingTIme = RateOfFire;

        //           StartCoroutine(BooleanShootingTime());

        //        }
        //        else
        //        {
        //           _ShootingTIme -= Time.deltaTime;
        //        }


        //    }

        //}
        #endregion

    }

    //void RandomNumber()
    //{
    //    _randomWaypoint = Random.Range(0, 3);
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        _currentState.OntriggerEnter(other);


    }

    public void TakeSupressionDamage(float Damage)
    {
        SuppressionHealth -= Damage;
        CurrentSuppressionHealth = SuppressionHealth;
        //do animation

        if (SuppressionHealth <= 0)
        {
            //Debug.Log("enemy supressed");
            //do animation

            if (CurrentSuppressionHealth <= 0)
            {
                ChangeState(new SniperBossMoveState());
                SuppressionHealth = RSuppressionHealth;
                //ChangeNumber = true;
            }

        }


    }



    public void MoveToCover()
    {

        if(WaypointIndex < 3)
        {
            MyAnimator.SetFloat("speed", 1);
            //MyAnimator.SetBool("isAttacking", false);
            //MyAnimator.SetBool("isAttacking2", false);
            //WPintIndex.transform.position = _waypoints[WaypointIndex].transform.position;
            this.transform.position = Vector2.MoveTowards(transform.position, Waypoints[WaypointIndex].transform.position,
                MoveSpeed * Time.deltaTime);

        }


        if(transform.position == Waypoints[WaypointIndex].transform.position)
        {
            MyAnimator.SetFloat("speed", 0);
            WaypointIndex = RandomWayPoint;
            ChangeNumber = true;
            //WPintIndex.transform.position = Waypoints[WaypointIndex].transform.position;
            
        }

    }





    public void ChangeState(IESniperBossStates newState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = newState;
        _currentState.Enter(this);


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


    public void Stop()
    {
        transform.position = this.transform.position;
    }


    public Vector2 GetPosition()
    {
        return transform.position;
    }


    //EngagementTime
    private IEnumerator BooleanShootingTime()
    {
        
        yield return new WaitForSeconds(EngagementTime);
        Debug.Log("FIRING!!!");
        CanShoot = false;
        

    }

    //reset EngagementTime
    public IEnumerator ResetShootingTime()
    {

        
        yield return new WaitForSeconds(ReloadingTime);
        Debug.Log("Reloading!!!");
        CanShoot = true;

    }



}
