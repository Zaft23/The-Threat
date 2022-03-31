using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb2D;
    //private Animator myAnimator;
    //will need animator when we have proper assets

    [Header("Public Vars")]
    public float Speed;
    public float HorizontalMovement;
    public float JumpForce;
    public bool IsGrounded;

    [Header("Private Vars")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _radOCircle;
    [SerializeField] private LayerMask _whatIsGround;

    void Start()
    {
        //
        rb2D = GetComponent<Rigidbody2D>();
        //myAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        HorizontalMovement = Input.GetAxisRaw("Horizontal");
        //HorizontalMovement = Input.GetAxis("Horizontal");
        //might need to check the difrrent feels of axis and axisraw


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_groundCheck.position, _radOCircle);
    }

    void FixedUpdate()
    {
        rb2D.velocity = new Vector2(HorizontalMovement * Speed, rb2D.velocity.y);


        IsGrounded = Physics2D.OverlapCircle(_groundCheck.position, _radOCircle, _whatIsGround);

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, JumpForce);
        }

    }

}
