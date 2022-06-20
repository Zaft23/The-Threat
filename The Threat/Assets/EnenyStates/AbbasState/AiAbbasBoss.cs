using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAbbasBoss : MonoBehaviour
{
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



    // Update is called once per frame
    void Update()
    {


        //ignore collision


        _currentState.Execute();
        //LookAtTarget();


        if (enemyStats.EnemyHealth <= enemyStats.SecondStageHealth)
        {
           
            Debug.Log("Second Stage");


            RushSpeed = 10f;
            RushDamage = 100f;
            Damage = 40f;
            ChaseSpeed = 5f;
            AttackDuration = 10f;
            IdleDuration = 2f;
            RushDuration = 7f;


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

        var Player = GameObject.FindGameObjectWithTag("Player").transform;


        //Behaviour
        //if withing line of sight 
        // do function
        //if enemy too far away to shoot
        if (Vector2.Distance(transform.position, Player.position) > range)
        {
            //Debug.Log("too far");
            transform.position = Vector2.MoveTowards(transform.position, Player.position, ChaseSpeed * Time.deltaTime);
        }
        //if enemy in range to engage player
        else if (Vector2.Distance(transform.position, Player.position) < range &&
            Vector2.Distance(transform.position, Player.position) > RetreatDistance)
        {


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
            playerHealth.TakeDamage(Damage);
    }

    public void AiMelee()
    {
        cooldownTimer += Time.deltaTime;


        //Attack only when player in sight?
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                DamagePlayer();
                //anim.SetTrigger("meleeAttack");
            }
        }


    }

    public void RushMelee()
    {

        if (PlayerInSight())
            playerHealth.TakeDamage(RushDamage);


    }




}
