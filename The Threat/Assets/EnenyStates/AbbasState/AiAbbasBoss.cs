using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAbbasBoss : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip AttackingSound;
    public AudioClip IdleSound;
    public AudioClip DashTelegraphSound;
    public AudioClip BreathingSound;
    public AudioClip WalkingSound;




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

    [SerializeField] private Player playerHealth;
    [SerializeField] private EnemyStats enemyStats;

    public Animator MyAnimator;

    public float Damage;
    public float RushDamage;
    public float RushSpeed;
    public float ChaseSpeed;
    public float ChaseSpeedR;

    public float AttackDuration;
    public float RushDuration;
    public float IdleDuration;




    public float AttackRange;
    public float RetreatDistance;

    public Vector3 Direction;



    public GameObject Gun;

    //public float AttackTimer;
    //public float AttackCooldown;




    public bool Attack { get; set; }
    private bool _facingRight;


    //public Animator Animator;
    private Rigidbody2D Rb2d;
    public GameObject Target;
    public GameObject GroundCheck;

    [SerializeField]
    public bool CanAttack;
    //public bool CanGiveDamage;

    private IEAbbasBossStates _currentState;







    private void Awake()
    {
        enemyStats = GetComponent<EnemyStats>();
        Rb2d = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
    }



    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.IgnoreLayerCollision(6, 7);
        //_currentHealth = EnemyHealth;
        _facingRight = true;

        ChangeState(new AbbasAttackState());

        CanAttack = true;

    }

    [SerializeField]
    private float SoundTimer;

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
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
        //LookAtTarget();


        if (enemyStats.EnemyHealth <= enemyStats.SecondStageHealth)
        {
           
            Debug.Log("Second Stage");


            RushSpeed = 15f;
            RushDamage = 100f;
            Damage = 70f;
            ChaseSpeed = 5f;
            AttackDuration = 10f;
            IdleDuration = 2f;
            RushDuration = 32f;


        }







    }

    //stage phase





    #region
    public void LookAtTarget()
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

    public void RushMove()
    {
        MyAnimator.SetBool("isDashing", true);
        transform.Translate(GetDirection() * (RushSpeed * Time.deltaTime));

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



    public void ChangeState(IEAbbasBossStates newState)
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
        LookAtTarget();

        var Player = GameObject.FindGameObjectWithTag("Player").transform;

        MyAnimator.SetFloat("speed", 1);
      
  
   
        //if enemy too far away to shoot
        if (Vector2.Distance(transform.position, Player.position) > range)
        {
            //MyAnimator.SetFloat("speed", 1f);
            //MyAnimator.SetBool("isAttacking", false);
            //Debug.Log("too far");
            transform.position = Vector2.MoveTowards(transform.position, Player.position, ChaseSpeed * Time.deltaTime);
        }
        //if enemy in range to engage player
        else if (Vector2.Distance(transform.position, Player.position) < range &&
            Vector2.Distance(transform.position, Player.position) > RetreatDistance)
        {

            MyAnimator.SetFloat("speed", 0);
        
            //Debug.Log("engage");
            transform.position = this.transform.position;
        }


        //if enemy too close to player
        else if (Vector2.Distance(transform.position, Player.position) < RetreatDistance)
        {
           // Debug.Log("too close");
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
        {


            playerHealth.TakeDamage(Damage);
            
            MyAnimator.SetBool("isAttacking", false);
        }
            
    }

    public void AiMelee()
    {




        //MyAnimator.SetFloat("speed", 0f);
        //MyAnimator.SetBool("isAttacking", true);





        //cooldownTimer += Time.deltaTime;
        if (enemyStats.EnemyHealth > enemyStats.SecondStageHealth)
        {
            //Attack only when player in sight?
            if (PlayerInSight())
            {


                //if (cooldownTimer >= attackCooldown)
                MyAnimator.SetFloat("attackSpeed", 1f);
                //{
                MyAnimator.SetFloat("speed", 0f);
                MyAnimator.SetBool("isAttacking", true);




                //cooldownTimer = 0;
                //DamagePlayer();
                ////anim.SetTrigger("meleeAttack");
                //}
            }
        }
        //Attack only when player in sight?
        if (enemyStats.EnemyHealth <= enemyStats.SecondStageHealth)
        {
            //Attack only when player in sight?
            if (PlayerInSight())
            {


                //if (cooldownTimer >= attackCooldown)
                //{
                MyAnimator.SetFloat("attackSpeed", 1.5f);
                MyAnimator.SetFloat("speed", 0f);
                MyAnimator.SetBool("isAttacking", true);




                //cooldownTimer = 0;
                //DamagePlayer();
                ////anim.SetTrigger("meleeAttack");
                //}
            }
        }




    }

    public void RushMelee()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= 2)
            {

                playerHealth.TakeDamage(RushDamage);

                cooldownTimer = 0;

            }
                



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

    public void TelegraphSound()
    {
        audioSource.PlayOneShot(IdleSound);
        audioSource.volume = 0.8f;
    }


    public void PlayAngrySound()
    {

        if (Target != null)
        {
            audioSource.PlayOneShot(IdleSound);
            audioSource.volume = 0.6f;
            //audioSource.pitch = Random.Range(0.5f, 1.1f);
        }






    }

    public void PlayBreathingSound()
    {


            //audioSource.PlayOneShot(BreathingSound);
            audioSource.volume = 0.4f;
            //audioSource.pitch = Random.Range(0.5f, 1.1f);
     






    }

    public void PlayWalkingSound()
    {


            audioSource.PlayOneShot(WalkingSound);
            audioSource.volume = 0.7f;
            //audioSource.pitch = 0.3f;
     






    }




}
