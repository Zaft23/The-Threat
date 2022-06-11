using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSniperBoss : MonoBehaviour
{
    public Weapon Weapon;

    //public float EnemyHealth;
    //private float _currentHealth;
    public float Damage;
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

    public GameObject Bullet;

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
    Transform[] _waypoints;
    private int _waypointIndex;
    private int _randomWaypoint;
    private bool _changeNumber;

    private void Awake()
    {

        Rb2d = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        //spawn here/location

        Physics2D.IgnoreLayerCollision(6, 7);
        //_currentHealth = EnemyHealth;
        _facingRight = true;
        ShootingTime = StartShootingTime;
        ChangeState(new SniperBossMoveState());
        //CanShoot = true;


        //
  
        transform.position = _waypoints[_waypointIndex].transform.position;
        _changeNumber = false;
    }



    // Update is called once per frame
    void Update()
    {
        _currentState.Execute();
        LookAtTarget();

        if(_changeNumber == true)
        {
            _randomWaypoint = Random.Range(0, 3);
        }
        

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

    //void RandomNumber()
    //{
    //    _randomWaypoint = Random.Range(0, 3);
    //}





    public void MoveToCover()
    {
        this.transform.position = Vector2.MoveTowards(transform.position, _waypoints[_waypointIndex].transform.position,
        MoveSpeed * Time.deltaTime);

        if(transform.position == _waypoints[_waypointIndex].transform.position)
        {
            _waypointIndex = _randomWaypoint;
            _changeNumber = true;
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



    private void OnTriggerEnter2D(Collider2D other)
    {
        _currentState.OntriggerEnter(other);
    }


    public void AiShoot()
    {

        var Player = GameObject.FindGameObjectWithTag("Player").transform;

        //if (CanShoot == true)
        //{
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
        //}






    }

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
