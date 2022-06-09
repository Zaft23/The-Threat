using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiEnemy : MonoBehaviour
{
    public Weapon Weapon;

    public float EnemyHealth;
    public float Damage;
    public float MoveSpeed;

    //private float _shootingRange = 5f;

    public Transform ShootPos;
    public GameObject Gun;

    public bool Attack {get; set;}
    private bool _facingRight;


    //public Animator Animator;
    private Rigidbody2D Rb2d;
    public GameObject Target;


    //Ai Controll

    //private IEnemyStates _currentState;

    

    // Start is called before the first frame update
    private void Awake()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _facingRight = true;
       // ChangeState(new IdleState());

    }

    //private void Flip(float horizontal)
    //{
    //    if(horizontal > 0 && !_facingRight || horizontal < 0 && _facingRight)
    //    {
    //        _facingRight = !_facingRight;
    //        Vector3 theScale = transform.localScale;
    //        theScale.x *= -1;
    //        transform.localScale = theScale;

    //    }

    //}

    //public void AiShoot()
    //{
    //    //monkey code
    //}




    // Update is called once per frame
    void Update()
    {
        //_currentState.Execute();
        LookAtTarget();
    }

    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if (xDir < 0 && _facingRight || xDir > 0 && !_facingRight)
            {
                //ChangeDirection();

            }

        }

    }

    //public void ChangeState(IEnemyStates newState)
    //{
    //    if(_currentState != null)
    //    {
    //        _currentState.Exit();
    //    }

    //    _currentState = newState;
    //    _currentState.Enter(this);


    }

    //public void Move()
   // {
        //animator
        // Rb2d.velocity = new Vector2(MoveSpeed * Time.fixedDeltaTime, Rb2d.velocity.y);

        //transform.Translate(GetDirection() * (MoveSpeed * Time.deltaTime));

   // }

    //flip

    //public void ChangeDirection()
    //{
    //    _facingRight = !_facingRight;
    //    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    //}


    //public Vector2 GetDirection()
    //{
    //    return _facingRight ? Vector2.right : Vector2.left;
    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    //_currentState.OntriggerEnter(other);
    //}

    //public void EnemyShoot()
    //{
    //    if(Vector3.Distance(transform.position,Player.Instance.GetPosition()) < _shootingRange)
    //    {
            
    //        //within attack range


    //    }

    //}

    //test
    //public void FindTarget()
    //{
    //    float targetRange = 5f;
    //    if(Vector3.Distance(transform.position, Player.Instance.GetPosition()) < targetRange)
    //    {
    //        Move();
    //    }

    //}











