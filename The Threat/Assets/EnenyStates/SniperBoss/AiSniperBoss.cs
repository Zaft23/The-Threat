using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSniperBoss : MonoBehaviour
{
    public Weapon Weapon;
    public Player Player;
    //public AiBossBulletBehaviour AiBullet;


    public EnemyStats EnemyStats;

    //
    public float SuppressionHealth;
    public float RSuppressionHealth;
    public float CurrentSuppressionHealth;
    public bool CanTakeDamage;
    public bool CanTakeSupression;
    public bool CanAttack;


    //public float EnemyHealth;
    //private float _currentHealth;
    //public float Damage;
    public float MoveSpeed;
    public float MoveSpeedR;
    public float FiringTime;
    public float ReloadingTime;

    //stoping distance
    public float ShootingRange;

    public Transform ShootPos;
    public Transform FirePoint;
    public Vector3 Direction;

    public GameObject Gun;

    public float RateOfFire;
    public float ShootingTime;
    public float StartShootingTime;
    public float EngagementTime;
    public float StartEngagementTime;

    //
   // public AiBossBulletBehaviour BulletStats;
    public GameObject Bullet;
    public GameObject Bullet2;


    public bool Attack { get; set; }
    private bool _facingRight;

    public float BulletSpeed;

    //public Animator Animator;
    private Rigidbody2D Rb2d;
    public GameObject Target;
    public GameObject GroundCheck;

    [SerializeField]
    //public bool CanShoot;

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
        //transform.position = _waypoints[rand].transform.position;
        //WPintIndex.transform.position = _waypoints[rand].transform.position;
        //rand = Random.Range(1, 3);
        RandomWayPoint = Random.Range(0, 3);
        //BulletStats = Bullet.GetComponent<AiBossBulletBehaviour>();
    }


    // Start is called before the first frame update
    void Start()
    {
        //spawn here/location

        Physics2D.IgnoreLayerCollision(6, 7);
        //_currentHealth = EnemyHealth;
        _facingRight = true;
        ShootingTime = StartShootingTime;
        ChangeState(new SniperBossAttackState());
        //ChangeState(new SniperBossMoveState());

        //CanShoot = true;
        CanTakeDamage = false;

        //
        

        //transform.position = _waypoints[rand.transform.position;
        //transform.position = _waypoints[1];
        transform.position = Waypoints[WaypointIndex].transform.position;
        //WPintIndex.transform.position = _waypoints[rand].transform.position;
        ChangeNumber = false;
        
        //
        RSuppressionHealth = SuppressionHealth;

        //
        EnemyStats = GetComponent<EnemyStats>();
        //BulletStats = Bullet.GetComponent<AiBossBulletBehaviour>;
        //var bBullet = Bullet.GetComponent<AiBossBulletBehaviour>();
        
        //public GameObject Bullet;


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

        //move mod and rate of fire
        if(EnemyStats.EnemyHealth <= EnemyStats.SecondStageHealth)
        {
            //AiBossBulletBehaviour bbullet = Bullet.GetComponent<AiBossBulletBehaviour>(); 
               // AiBossBulletBehaviour bbulet.GetComponent<AiBossBulletBehaviour>();
            //AiBullet = Bullet.GetComponent<AiBossBulletBehaviour>();
            Debug.Log("Second Stage");
            MoveSpeed = 10f;
           // BulletStats.Damage = 60f;
           // BulletStats.BulletSpeed = 100f;
            RateOfFire = 1f;

        }

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

            //if (_canShoot == false)
            //{
            //    StartCoroutine(ResetShootingTime());
            //}


    }

    public void AiShoot()
    {

        var Player = GameObject.FindGameObjectWithTag("Player").transform;

        //if (CanShoot == true)
        //{
        if (EnemyStats.EnemyHealth > EnemyStats.SecondStageHealth)
        {
            if (ShootingTime <= 0)
            {
                Debug.Log("amkiiiiiiiiiiiiiinh");
                GameObject bullet = Instantiate(Bullet, FirePoint.position, Quaternion.identity);

                ShootingTime = RateOfFire;

                //StartCoroutine(BooleanShootingTime());

            }
            else
            {
                ShootingTime -= Time.deltaTime;
            }
        }
        else
        {
            
                if (ShootingTime <= 0)
                {
                    Debug.Log("second Staaaaaaaaaaage");
                    GameObject bullet = Instantiate(Bullet2, FirePoint.position, Quaternion.identity);

                    ShootingTime = RateOfFire;

                    //StartCoroutine(BooleanShootingTime());

                }
                else
                {
                    ShootingTime -= Time.deltaTime;
                }
            
        }

        
        
        //}

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
            Debug.Log("enemy supressed");
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
           //WPintIndex.transform.position = _waypoints[WaypointIndex].transform.position;
            this.transform.position = Vector2.MoveTowards(transform.position, Waypoints[WaypointIndex].transform.position,
                MoveSpeed * Time.deltaTime);

        }


        if(transform.position == Waypoints[WaypointIndex].transform.position)
        {
            WaypointIndex = RandomWayPoint;
            ChangeNumber = true;
            //WPintIndex.transform.position = Waypoints[WaypointIndex].transform.position;
            //CanShoot = true;
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



  //  private void OnTriggerEnter2D(Collider2D other)
   // {
        //_currentState.OntriggerEnter(other);
   // }




    public void Stop()
    {
        transform.position = this.transform.position;
    }


    public Vector2 GetPosition()
    {
        return transform.position;
    }

    //private IEnumerator ResetChaseSpeed()
    //{
    //    yield return new WaitForSeconds(7);
    //    ChaseSpeed = ChaseSpeedR;
    //    //ChangeDirection();

    //}

    //private IEnumerator BooleanShootingTime()
    //{
    //    yield return new WaitForSeconds(FiringTime);

    //    CanShoot = false;
    //    //ChangeDirection();

    //}

    //private IEnumerator ResetShootingTime()
    //{
    //    yield return new WaitForSeconds(ReloadingTime);

    //    CanShoot = true;

    //}








}
