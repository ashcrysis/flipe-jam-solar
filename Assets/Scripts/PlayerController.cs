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
    private bool isMoving;
    private Vector2 lastFacedDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        velocity = GameObject.FindGameObjectWithTag("GameController").GetComponent<ENVIRONMENT_VARIABLES>().PLAYER_BASE_MOVEMENT_SPEED;
    }

    void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal" + playerNumber);
        var verticalInput = Input.GetAxisRaw("Vertical" + playerNumber);

        direction = new Vector2(horizontalInput, verticalInput);

        if (direction != Vector2.zero)
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
            //anim.SetFloat("y", direction.y);
        }
        else
        {
            anim.SetFloat("x", lastFacedDirection.x);
            //anim.SetFloat("y", lastFacedDirection.y);
        }
        if (isMoving)
        {
            GetComponent<SpriteRenderer>().flipX = direction.x < 0;
        }else
        {
            GetComponent<SpriteRenderer>().flipX = lastFacedDirection.x < 0;
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            rb.velocity = direction * velocity;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
