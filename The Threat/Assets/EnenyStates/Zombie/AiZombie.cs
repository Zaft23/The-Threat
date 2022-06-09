using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiZombie : MonoBehaviour
{

    //public float EnemyHealth;
    //private float _currentHealth;
    public float Damage;
    public float MoveSpeed;
    public float ChaseSpeed;
    public float ChaseSpeedR;
    //public float FiringTime;
    //public float ReloadingTime;

    //stoping distance
    public float AttackRange;
    public float RetreatDistance;


    public Vector3 Direction;



    public GameObject Gun;

    public float AttackTimer;
    public float AttackCooldown;
    //public float StartShootingTime;
    //public float EngagementTime;
    //public float StartEngagementTime;

    //public Collider2D MAttack;



    public bool Attack { get; set; }
    private bool _facingRight;

    
    //public Animator Animator;
    private Rigidbody2D Rb2d;
    public GameObject Target;
    public GameObject GroundCheck;

    [SerializeField]
    public bool CanAttack;
    //public bool CanGiveDamage;

    private IEZombieStates _currentState;







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
        //ShootingTime = StartShootingTime;
        ChangeState(new ZombieIdleState());

        CanAttack = true;
        //CanGiveDamage = true;
}



    // Update is called once per frame
    void Update()
    {


       
        //ignore collision


        _currentState.Execute();
        LookAtTarget();

        if (GroundCheck == null)
        {

            //MoveSpeed = 0;

            ChaseSpeed = 0;

        }

        if(CanAttack == false)
        {
            AiAttack();
            //StartCoroutine(AttackR());
            //MAttack.enabled = true;
        }

        //if(CanGiveDamage == false)
        //{
  

        //    StartCoroutine(AttackR());

        //}


        if (ChaseSpeed == 0 && Target == null )
        {
            StartCoroutine(ResetChaseSpeed());
            
            Debug.Log("target dissapear");
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



    public void ChangeState(IEZombieStates newState)
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



    public void AiMelee()
    {



        var Player = GameObject.FindGameObjectWithTag("Player").transform;

        
 
            //if enemy too far away to shoot
            if (Vector2.Distance(transform.position, Player.position) > AttackRange)
            {
                Debug.Log("too far");
                transform.position = Vector2.MoveTowards(transform.position, Player.position, ChaseSpeed * Time.deltaTime);
            }
            //if enemy in range to engage player
            else if (Vector2.Distance(transform.position, Player.position) < AttackRange &&
                Vector2.Distance(transform.position, Player.position) > RetreatDistance)
            {


                Debug.Log("engage");
                transform.position = this.transform.position;
            }


            ////if enemy too close to player
            else if (Vector2.Distance(transform.position, Player.position) < RetreatDistance)
            {
                Debug.Log("too close");
                transform.position = Vector2.MoveTowards(transform.position, Player.position, -ChaseSpeed * Time.deltaTime);
            }


        //AiAttack();
        
        



    }


    public void AiAttack()
    {

        Debug.Log("atttackaiiiiiiiiiiiii");

        AttackTimer += Time.deltaTime;
        if(AttackTimer >= AttackCooldown)
        {

            //var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            //player.TakeDamage(Damage);
            
            CanAttack = true;
            AttackTimer = 0;

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

    //private IEnumerator AttackR()
    //{
    //    var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    //    player.TakeDamage(Damage);
    //    //var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    //    //player.TakeDamage(Damage);

    //    yield return new WaitForSeconds(AttackCooldown);
    //    CanGiveDamage = true;
    //    //MAttack.enabled = true;


    //}








}

