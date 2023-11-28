using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enzym.Movement
{
    public class Movement : MonoBehaviour
    {
        public float MoveSpeed;
        private bool isFacingRight = true;
        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            
        }

        public void PlayerMove()
        {
            // Get input for horizontal movement
            float moveInput = Input.GetAxis("Horizontal");

            // Move the player horizontally
            rb.velocity = new Vector2(moveInput * MoveSpeed, rb.velocity.y);

            // Flip the object based on input
            if (moveInput > 0 && !isFacingRight)
            {
                FlipObject();
            }
            else if (moveInput < 0 && isFacingRight)
            {
                FlipObject();
            }

        }


        private void FlipObject()
        {
            // Flip the object horizontally
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFacingRight = !isFacingRight;
        }
    }
}

