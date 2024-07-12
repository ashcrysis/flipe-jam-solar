using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 direction;
    private Rigidbody2D rb;
    private float velocity;
    public int playerNumber;
    internal Animator anim;
    public bool isMoving;
    private Vector2 lastFacedDirection;
    public float jumpForce = 8f;
     public LayerMask groundLayer;
     public Transform groundCheck;
    public bool isGrounded;
    public float isGroundedRadius = 0.1f;
    public bool jumping;
    public bool isFacingRight = true;
    private float horizontalInput;
    private float verticalInput;
    public bool hasDoubleJumped;
    public int jumpCount;
    public int extraJumps = 1;
    public int points = 0;

    public bool isDoubleJumping = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        velocity = GameObject.FindGameObjectWithTag("GameController").GetComponent<ENVIRONMENT_VARIABLES>().PLAYER_BASE_MOVEMENT_SPEED;
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal" + playerNumber);
        verticalInput = Input.GetAxisRaw("Vertical" + playerNumber);

        Flip();

        direction = new Vector2(horizontalInput, rb.velocity.y);
        isGrounded = IsGrounded();

        anim.SetBool("isJumping", !isGrounded);

        if (direction.x != 0)
        {
            isMoving = true;
            lastFacedDirection = direction;
            anim.SetBool("isMoving", true);
        }
        else
        {
            isMoving = false;
            anim.SetBool("isMoving", false);
        }
        


        if (Input.GetButtonDown("Fire1_" + playerNumber))
        {
            jumping = true;
        }
        if (IsGrounded())
        {
            jumpCount = 0;
            anim.SetBool("DoubleJump", false);
        }

        if(jumpCount > 0 && isDoubleJumping){
            anim.SetBool("DoubleJump", true);
        }
    }
void Jump()
{
    if (isGrounded)
    {
        jumpCount = 0; 
        hasDoubleJumped = false;

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpCount++;


    }
    else if (jumpCount < extraJumps - 1)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0); 
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpCount++;

    }
}

    void FixedUpdate()
{
    if (isMoving && !GetComponent<Dash>().isDashing)
    {
        rb.velocity = new Vector2(direction.x * velocity, rb.velocity.y);
    }
    else if (!isMoving && !GetComponent<Dash>().isDashing)
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    if (jumping)
    {
        
        Jump();
        jumping = false;
    }
}
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
     private void Flip()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Item")){
            float delay = 0f;
            points++;
            Destroy(other.gameObject, delay);
        }
    }

}
