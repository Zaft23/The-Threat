using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public AudioClip RunningSound;
    public AudioClip JumpSound;
    public AudioClip DashSound;

    //public GameObject DashTrail;

    #region
    [Header("Components")]
    private Rigidbody2D rb2D;
    private Animator MyAnimator;
    public PlayerActions Actions;


    //private Animator myAnimator;
    //will need animator when we have proper assets

    [Header("Movement Details")]
    public float Speed;
    public float horizontalMovement;
    public bool IsRunning;



    [Header("Ground Check")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _radOCircle;
    [SerializeField] private LayerMask _whatIsGround;
    public bool IsGrounded;

    
    [Header("Dashing")]
    [SerializeField] private float _dashingVelocity = 14f;
    [SerializeField] private float _dashingTime = 0.5f;
    private Vector2 _dashingDir;
    private bool _isDashing;
    private bool _canDash = true;
    public TrailRenderer TrailRenderer;


    [Header("Jump Gravity")]
    public float FallMupltiplier = 2.5f;
    public float LowJumpMultiplier = 2f;


    [Header("Jump details")]
    public float JumpForce;
    //[SerializeField] private float _yVelJumpReleasedMod = 2F;
    [SerializeField] private float _fJumpPressedRememberTime;
    [SerializeField] private float _fJumpPressedRemember = 0;
    [SerializeField] float _coyoteRemember = 0;
    [SerializeField] float _coyoteRememberTime = 0.3f;

    [Header("Corner Correction Variables")]
    [SerializeField] private float _topRaycastLength;
    [SerializeField] private Vector3 _edgeRaycastOffset;
    [SerializeField] private Vector3 _innerRaycastOffset;
    [SerializeField] private LayerMask _cornerCorrectLayer;
    private bool _canCornerCorrect;
    //
    public Transform CrossHair;
    #endregion

    private Player player;

    


    void Awake()
    {
        player = GetComponent<Player>();

        //
        rb2D = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
        Actions = GetComponent<PlayerActions>();
        //myAnimator = GetComponent<Animator>();
        //_trailRenderer = GetComponent<TrailRenderer>();
        IsRunning = false;

    }

    private void Start()
    {

        TrailRenderer = GetComponent<TrailRenderer>();

    }

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Dash"))
        {
            audioSource.PlayOneShot(DashSound);
            audioSource.volume = 0.5f;
        }
      

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_groundCheck.position, _radOCircle);
        //Corner Check
        Gizmos.DrawLine(transform.position + _edgeRaycastOffset, transform.position + _edgeRaycastOffset + Vector3.up * _topRaycastLength);
        Gizmos.DrawLine(transform.position - _edgeRaycastOffset, transform.position - _edgeRaycastOffset + Vector3.up * _topRaycastLength);
        Gizmos.DrawLine(transform.position + _innerRaycastOffset, transform.position + _innerRaycastOffset + Vector3.up * _topRaycastLength);
        Gizmos.DrawLine(transform.position - _innerRaycastOffset, transform.position - _innerRaycastOffset + Vector3.up * _topRaycastLength);

        //Corner Distance Check
        Gizmos.DrawLine(transform.position - _innerRaycastOffset + Vector3.up * _topRaycastLength,
                        transform.position - _innerRaycastOffset + Vector3.up * _topRaycastLength + Vector3.left * _topRaycastLength);
        Gizmos.DrawLine(transform.position + _innerRaycastOffset + Vector3.up * _topRaycastLength,
                        transform.position + _innerRaycastOffset + Vector3.up * _topRaycastLength + Vector3.right * _topRaycastLength);
    }

    void FixedUpdate()
    {



        #region
        var dashInput = Input.GetButtonDown("Dash");
        float eulerAngY = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).y;
        //if(Actions.)
        //
        //else if(eulerAngY == -180 && Input.GetKeyDown(KeyCode.D))
        if (Input.GetKeyDown(KeyCode.D) && eulerAngY == 0)
        {

     

            //Debug.Log("Forward1");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", 1.0f);

        }
        else if (Input.GetKeyDown(KeyCode.A) && eulerAngY == -180)
        {

            //Debug.Log("Forward2");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", 1.0f);
        }
        else if (Input.GetKeyDown(KeyCode.A) && eulerAngY == 0)
        {

            //Debug.Log("BackWard1");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", -1.0f);

        }
        else if (Input.GetKeyDown(KeyCode.D) && eulerAngY == -180)
        {
            //audioSource.Play();
            //audioSource.loop = true;
            //audioSource.PlayOneShot(RunningSound);
            //Debug.Log("BackWard2");
            //MyAnimator.SetBool("IsRunning", true);
            MyAnimator.SetFloat("speed", -1.0f);
        }
        //else
        //{
        //    audioSource.loop = false;

        //}


        XMovement();




        if (dashInput && _canDash)
        {
           

            _isDashing = true;
            _canDash = false;
            TrailRenderer.emitting = true;

            _dashingDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            //_trailRenderer.emitting = true;
            if (_dashingDir == Vector2.zero)
            {
                _dashingDir = new Vector2(transform.localScale.x, 0);
            }

            StartCoroutine(StopDashing());

        }

        //animator.SetBool("IsDashing", _isDashing);

        if (_isDashing)
        {
            rb2D.velocity = _dashingDir.normalized * _dashingVelocity;
            return;
        }

        if (IsGrounded)
        {
            _canDash = true;
        }


       

        CheckCollisions();
        //
        


        // Jump Physics
        IsGrounded = Physics2D.OverlapCircle(_groundCheck.position, _radOCircle, _whatIsGround);

        _coyoteRemember -= Time.deltaTime;
        if (IsGrounded)
        {
            _coyoteRemember = _coyoteRememberTime;
        }


        //better code
        _fJumpPressedRemember -= Time.deltaTime;
        //if (Input.GetButtonDown("Jump"))
        //{
        //    _fJumpPressedRemember = _fJumpPressedRememberTime;
        //    //Debug.Log("Jump");
        //}

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            audioSource.PlayOneShot(DashSound);
            audioSource.volume = 0.5f;
            _fJumpPressedRemember = _fJumpPressedRememberTime;
            rb2D.velocity = new Vector2(rb2D.velocity.x, y: JumpForce);
            Debug.Log("Jump2");
        }

        //Allow player to jump a few cm off from ground after jump
        if ((_fJumpPressedRemember > 0) && (_coyoteRemember > 0))
        {
           _fJumpPressedRemember = 0;
            _coyoteRemember = 0;
            rb2D.velocity = new Vector2(rb2D.velocity.x, y: JumpForce);

        }

        if (rb2D.velocity.y < 0)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (FallMupltiplier -1) * Time.deltaTime;
        }
        else if(rb2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime;
        }

        //if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0)
        //{
        //    rb2D.velocity = new Vector2(rb2D.velocity.x, y:rb2D.velocity.y / _yVelJumpReleasedMod);
        //}

        //Corner Correction
        if (_canCornerCorrect) CornerCorrect(rb2D.velocity.y);





        //found from another tutorial https://www.youtube.com/watch?v=Mo1-sKYbks0&ab_channel=PitiIT i assume it's to control the basic X axis movement for now just ignore
        //if (horizontalMovement != 0)
        //{
        //    transform.localScale = new Vector3(x: Mathf.Sign(horizontalMovement), y: 1, z: 1);
        //}
        #endregion

    }


   public void PlayRunningSound()
    {
        if(IsGrounded == true)
        {
            audioSource.PlayOneShot(RunningSound);
            audioSource.volume = 0.2f;
            //audioSource.pitch = Random.Range(0.5f, 1.1f);
        }


    }
    

    #region
    //Corner Correction
    void CornerCorrect(float yVelocity)
    {
        //Push player to the right
        RaycastHit2D _hit = Physics2D.Raycast(transform.position - _innerRaycastOffset + Vector3.up * _topRaycastLength, Vector3.left, _topRaycastLength, _cornerCorrectLayer);
        if (_hit.collider != null)
        {
            float _newPos = Vector3.Distance(new Vector3(_hit.point.x, transform.position.y, 0f) + Vector3.up * _topRaycastLength,
                transform.position - _edgeRaycastOffset + Vector3.up * _topRaycastLength);
            transform.position = new Vector3(transform.position.x + _newPos, transform.position.y, transform.position.z);
            rb2D.velocity = new Vector2(rb2D.velocity.x, yVelocity);
            return;
        }

        //Push player to the left
        _hit = Physics2D.Raycast(transform.position + _innerRaycastOffset + Vector3.up * _topRaycastLength, Vector3.right, _topRaycastLength, _cornerCorrectLayer);
        if (_hit.collider != null)
        {
            float _newPos = Vector3.Distance(new Vector3(_hit.point.x, transform.position.y, 0f) + Vector3.up * _topRaycastLength,
                transform.position + _edgeRaycastOffset + Vector3.up * _topRaycastLength);
            transform.position = new Vector3(transform.position.x - _newPos, transform.position.y, transform.position.z);
            rb2D.velocity = new Vector2(rb2D.velocity.x, yVelocity);
        }
    }

    void CheckCollisions()
    {

        //Corner Collisions
        _canCornerCorrect = Physics2D.Raycast(transform.position + _edgeRaycastOffset, Vector2.up, _topRaycastLength, _cornerCorrectLayer) &&
        !Physics2D.Raycast(transform.position + _innerRaycastOffset, Vector2.up, _topRaycastLength, _cornerCorrectLayer) ||
        Physics2D.Raycast(transform.position - _edgeRaycastOffset, Vector2.up, _topRaycastLength, _cornerCorrectLayer) &&
        !Physics2D.Raycast(transform.position - _innerRaycastOffset, Vector2.up, _topRaycastLength, _cornerCorrectLayer);



    }

    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(_dashingTime);
        TrailRenderer.emitting = false;
        _isDashing = false;
      

    }

    public void XMovement()
    {
        //Handles basic X axis Movement
        

        rb2D.velocity = new Vector2(horizontalMovement * (Speed + player.BaseSpeed), rb2D.velocity.y);
        //float eulerAngY = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).y;

        if (horizontalMovement == 0)
        {
            MyAnimator.SetBool("IsRunning", false);
        }
        else
        {
            MyAnimator.SetBool("IsRunning", true);

            //if (eulerAngY == 0 && horizontalMovement == 1)


            //    if (horizontalMovement == 1)
            //    {
            //        MyAnimator.SetFloat("speed", 1.0f);
            //    }


            ////if(horizontalMovement == 1)
            //if (eulerAngY == 180 || eulerAngY == 0)
            //{
            //    //Debug.Log("Right!!!!!!!!!!");
            //    MyAnimator.SetBool("IsFacingRight", true);


            //}
            //else if(eulerAngY == -180)
            //{
            //    //Debug.Log("Left!!!!!!!!!!");
            //    MyAnimator.SetBool("IsFacingRight", false);
            //    MyAnimator.speed = -1;
            //}

        }

    }
    #endregion




}
