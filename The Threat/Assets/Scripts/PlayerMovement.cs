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

   // [Header("Gravity")]

    [Header("Jump details")]
    //jump height
    public float JumpForce;
    [SerializeField] private float _yVelJumpReleasedMod = 2F;


    void Start()
    {
        //
        rb2D = GetComponent<Rigidbody2D>();
        //myAnimator = GetComponent<Animator>();

       

    }
    
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        //HorizontalMovement = Input.GetAxis("Horizontal");
        //might need to check the difrrent feels of axis and axisraw


    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_groundCheck.position, _radOCircle);
    }
   
    void FixedUpdate()
    {
        
        //Handles basic X axis Movement
        rb2D.velocity = new Vector2(horizontalMovement * Speed, rb2D.velocity.y);

        //Handles ground check and Y Axis (Jump) Movement
        IsGrounded = Physics2D.OverlapCircle(_groundCheck.position, _radOCircle, _whatIsGround);

        // Jump Control using Variable Height Jump
        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, y: JumpForce);

        }

        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, y:rb2D.velocity.y / _yVelJumpReleasedMod);
        }

        //found from another tutorial https://www.youtube.com/watch?v=Mo1-sKYbks0&ab_channel=PitiIT i assume it's to control the basic X axis movement for now just ignore
        //if (horizontalMovement != 0)
        //{
        //    transform.localScale = new Vector3(x: Mathf.Sign(horizontalMovement), y: 1, z: 1);
        //}




    }

}
