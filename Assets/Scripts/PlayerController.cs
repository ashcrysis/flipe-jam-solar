using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 direction;
    private Rigidbody2D rb;
    private float velocity;
    public int playerNumber;
    private Animator anim;
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
        if (direction.x != 0)
        {
            isMoving = true;
            lastFacedDirection = direction;
        }
        else
        {
            isMoving = false;
        }

        anim.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            anim.SetFloat("x", direction.x);
        }
        else
        {
            anim.SetFloat("x", lastFacedDirection.x);
        }

        if (Input.GetButtonDown("Fire1_" + playerNumber) && IsGrounded())
        {
            jumping = true;
        }
    }
    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Force);
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
        }
    }

}
