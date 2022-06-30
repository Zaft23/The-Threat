using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiSoldier : MonoBehaviour
{
    //private float _lastShootTime;

    //public Weapon Weapon;
    public GameObject Muzzle;
    public AudioSource audioSource;
    public AudioClip AttackingSound;
    //public AudioClip WalkingSound;
    //public float EnemyHealth;
    //private float _currentHealth;
    //public float Damage;

    public Animator MyAnimator;

    public float MoveSpeed;
    public float ChaseSpeed;
    public float ChaseSpeedR;
    public float EngagementTime;
    public float ReloadingTime;

    //stoping distance
    public float ShootingRange;
    public float RetreatDistance;




    public Transform ShootPos;
    public Transform FirePoint;
    public Vector3 Direction;



    public GameObject Gun;

    public float RateOfFire;
    public float ShootingTime;
    public float IdleDuration;
    public float PatrolDuration;

    public float StartShootingTime;
    //public float EngagementTime;
    //public float StartEngagementTime;

    public GameObject Bullet;


    public bool Attack { get; set; }
    private bool _facingRight;

    public float BulletSpeed;

    //public Animator Animator;
    private Rigidbody2D Rb2d;
    public GameObject Target;
    public GameObject GroundCheck1;
    public GameObject GroundCheck2;

    [SerializeField]
    private bool _canShoot;


    private IESoldierStates _currentState;







    private void Awake()
    {
        MyAnimator = GetComponent<Animator>();
        Rb2d = GetComponent<Rigidbody2D>();
    }



    // Start is called before the first frame update
    void Start()
    {
        cooldownTimer = EngagementTime;
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

        if (GroundCheck1 == null || GroundCheck2 == null)
        {


            ChaseSpeed = 0;

        }


        if (ChaseSpeed == 0 && Target == null)
        {
            StartCoroutine(ResetChaseSpeed());

            Debug.Log("target dissapear");
        }

        //if(_canShoot == false)
        //{
        //    MyAnimator.SetBool("isAttacking", false);
        //    MyAnimator.SetBool("isReloading", true);
        //    StartCoroutine(ResetShootingTime());
        //}



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
        //audioSource.PlayOneShot(WalkingSound);

        audioSource.volume = 0.2f;

        MyAnimator.SetFloat("speed", 1);
        transform.Translate(GetDirection() * (MoveSpeed * Time.deltaTime));
        MyAnimator.SetBool("isAttacking", false);
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

    [SerializeField]
    private float cooldownTimer;

    public void AiShoot()
    {
        var Player = GameObject.FindGameObjectWithTag("Player").transform;

        if (Vector2.Distance(transform.position, Player.position) > ShootingRange)
        {
            MyAnimator.SetFloat("speed", 1);
            MyAnimator.SetBool("isAttacking", false);

            Debug.Log("too far");
            transform.position = Vector2.MoveTowards(transform.position, Player.position, ChaseSpeed * Time.deltaTime);
        }
        //if enemy in range to engage player
        else if (Vector2.Distance(transform.position, Player.position) < ShootingRange &&
                Vector2.Distance(transform.position, Player.position) > RetreatDistance)
        {
            MyAnimator.SetFloat("speed", 0);

            cooldownTimer -= Time.deltaTime;

            //if (_canShoot == true)


            if (cooldownTimer <= 0)
            {
                _canShoot = false;
                MyAnimator.SetBool("isAttacking", false);
                MyAnimator.SetBool("isReloading", true);

            }
            if (cooldownTimer <= -ReloadingTime)
            {
                _canShoot = true;
                MyAnimator.SetBool("isReloading", false);
                MyAnimator.SetBool("isAttacking", true);
                cooldownTimer = EngagementTime;
            }

            if (ShootingTime <= 0 && _canShoot == true)
            {
                audioSource.PlayOneShot(AttackingSound);
                audioSource.volume = 0.5f;

                MyAnimator.SetBool("isAttacking", true);
                GameObject bullet = Instantiate(Bullet, FirePoint.position, Quaternion.identity);
                GameObject effect = Instantiate(Muzzle, FirePoint.position, Quaternion.identity);
                ShootingTime = RateOfFire;



            }
            else
            {

                ShootingTime -= Time.deltaTime;
            }



            Debug.Log("engage");
            transform.position = this.transform.position;
        }


        //if enemy too close to player
        else if (Vector2.Distance(transform.position, Player.position) < RetreatDistance)
        {
            Debug.Log("too close");
            transform.position = Vector2.MoveTowards(transform.position, Player.position, -ChaseSpeed * Time.deltaTime);
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
        yield return new WaitForSeconds(EngagementTime);

        _canShoot = false;
        //ChangeDirection();

    }

    private IEnumerator ResetShootingTime()
    {
        yield return new WaitForSeconds(ReloadingTime);

        _canShoot = true;

    }



    //public void PlayStepSound()
    //{

    //    audioSource.PlayOneShot(WalkingSound);
    //    audioSource.volume = 0.2f;
    //    //audioSource.pitch = Random.Range(0.5f, 1.1f);





    //}
}