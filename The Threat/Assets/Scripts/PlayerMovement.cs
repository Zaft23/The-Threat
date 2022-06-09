using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    [Header("Components")]
    private Rigidbody2D rb2D;
    //private Animator myAnimator;
    //will need animator when we have proper assets

    [Header("Movement Details")]
    public float Speed;
    public float horizontalMovement;

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
    //private TrailRenderer _trailRenderer;
    //TEST


    [Header("Jump Gravity")]
    public float FallMupltiplier = 2.5f;
    public float LowJumpMultiplier = 2f;


    [Header("Jump details")]
    public float JumpForce;
    [SerializeField] private float _yVelJumpReleasedMod = 2F;
    [SerializeField] private float _fJumpPressedRememberTime = 0.2f;
    [SerializeField] private float _fJumpPressedRemember = 0;
    [SerializeField] float _coyoteRemember = 0;
    [SerializeField] float _coyoteRememberTime = 0.3f;

    [Header("Corner Correction Variables")]
    [SerializeField] private float _topRaycastLength;
    [SerializeField] private Vector3 _edgeRaycastOffset;
    [SerializeField] private Vector3 _innerRaycastOffset;
    [SerializeField] private LayerMask _cornerCorrectLayer;
    private bool _canCornerCorrect;





    void Awake()
    {
        //
        rb2D = GetComponent<Rigidbody2D>();
        //myAnimator = GetComponent<Animator>();
        //_trailRenderer = GetComponent<TrailRenderer>();


    }

    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");



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
        
        var dashInput = Input.GetButtonDown("Dash");

        if(dashInput && _canDash)
        {
            _isDashing = true;
            _canDash = false;
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

        //Handles basic X axis Movement
        rb2D.velocity = new Vector2(horizontalMovement * Speed, rb2D.velocity.y);

        // Jump Physics
        IsGrounded = Physics2D.OverlapCircle(_groundCheck.position, _radOCircle, _whatIsGround);

        _coyoteRemember -= Time.deltaTime;
        if (IsGrounded)
        {
            _coyoteRemember = _coyoteRememberTime;
        }


        //better code
        _fJumpPressedRemember -= Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            _fJumpPressedRemember = _fJumpPressedRememberTime;
            //Debug.Log("Jump");
        }

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, y: JumpForce);
            //Debug.Log("Jump2");
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

    }

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
        //_trailRenderer.emitting = false;
        _isDashing = false;


    }


  




}
