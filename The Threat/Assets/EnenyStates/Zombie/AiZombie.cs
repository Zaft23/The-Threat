using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiZombie : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioSource audioSource2;
    public AudioClip AttackingSound;
    public AudioClip IdleSound;



    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    //[SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    public Animator MyAnimator;



    private Player playerHealth;

    public float Damage;
    public float MoveSpeed;
    public float ChaseSpeed;
    public float ChaseSpeedR;

    public float AttackRange;
    public float RetreatDistance;


    public Vector3 Direction;



    public GameObject Gun;

    public float AttackTimer;
    public float AttackCooldown;
    public float IdleDuration;
    public float PatrolDuration;



    public bool Attack { get; set; }
    private bool _facingRight;

    
    //public Animator Animator;
    private Rigidbody2D Rb2d;
    public GameObject Target;
    public GameObject GroundCheck1;
    public GameObject GroundCheck2;

    [SerializeField]
    public bool CanAttack;
    //public bool CanGiveDamage;

    private IEZombieStates _currentState;







    private void Awake()
    {
        MyAnimator = GetComponent<Animator>();
        Rb2d = GetComponent<Rigidbody2D>();

    }



    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.IgnoreLayerCollision(6, 7);
        //_currentHealth = EnemyHealth;
        _facingRight = true;
        
        ChangeState(new ZombieIdleState());

        CanAttack = true;
        
    }

    [SerializeField]
    private float SoundTimer;

    // Update is called once per frame
    void Update()
    {

        if(Target != null)
        {
            SoundTimer += Time.deltaTime;
            if (SoundTimer >= 5f)
            {
                PlayAngrySound();
                SoundTimer = 0;
            }
           


        }
    

        //ignore collision


        _currentState.Execute();
        LookAtTarget();

        if (GroundCheck1 == null || GroundCheck2 == null)
        {


            ChaseSpeed = 0;

        }





        if (ChaseSpeed == 0 && Target == null )
        {
            StartCoroutine(ResetChaseSpeed());
            
            Debug.Log("target dissapear");
        }




    }


    #region
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
        MyAnimator.SetFloat("speed", 1);
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

    #endregion 

    public void AiChase()
    {

        var Player = GameObject.FindGameObjectWithTag("Player").transform;

        MyAnimator.SetFloat("speed", 1);

        //Behaviour
        //if withing line of sight 
        // do function
        //if enemy too far away to shoot
        if (Vector2.Distance(transform.position, Player.position) > range)
        {
            Debug.Log("too far");
            transform.position = Vector2.MoveTowards(transform.position, Player.position, ChaseSpeed * Time.deltaTime);
        }
        //if enemy in range to engage player
        else if (Vector2.Distance(transform.position, Player.position) < range &&
            Vector2.Distance(transform.position, Player.position) > RetreatDistance)
        {

            MyAnimator.SetFloat("speed", 0);
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










    // new attack logic
    private bool PlayerInSight()
    {
        RaycastHit2D hit =
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Player>();

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
            playerHealth.TakeDamage(Damage);
        MyAnimator.SetBool("isStopping", true);
        MyAnimator.SetBool("isAttacking", false);
    }

    public void AiMelee()
    {
        cooldownTimer += Time.deltaTime;


        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                MyAnimator.SetBool("isStopping", false);
                MyAnimator.SetBool("isAttacking", true);
                
                cooldownTimer = 0;
                //DamagePlayer();
                //anim.SetTrigger("meleeAttack");
            }
            //else
            //{
                //MyAnimator.SetBool("isAttacking", false);
            //}
        }


    }


    public void PlayAttackSound()
    {

        if (Target != null)
        {
            audioSource.PlayOneShot(AttackingSound);
            audioSource.volume = 0.3f;
            //audioSource.pitch = Random.Range(0.5f, 1.1f);
        }






    }


    public void PlayAngrySound()
    {

        if(Target != null)
        {
            audioSource.PlayOneShot(IdleSound);
            audioSource.volume = 0.6f;
            //audioSource.pitch = Random.Range(0.5f, 1.1f);
        }






    }







}

