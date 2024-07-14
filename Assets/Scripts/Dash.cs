using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private bool canDash = true;
    public float dashingPower = 10f;
    private float dashingTime = 0.35f;
    public float IFrames = 0.25f;
    public bool invincible = false;
    public float dashingCooldown = 1f;
    [SerializeField] private Transform dashCheck;
    private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    public bool isDashing;
    private bool isFacingRight;
    private float dir = 1f;
    private PlayerController player;
    private CapsuleCollider2D playerCollider;
    private Animator anim;
    private string fireAxis;

    void Start()
    {
        player = GetComponent<PlayerController>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        fireAxis = "Fire3_" + player.playerNumber;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isFacingRight = player.isFacingRight;
        dir = isFacingRight ? 1f : -1f;

        if (!player.IsGrounded())
        {
            invincible = false;
        }
        if (Input.GetButtonDown(fireAxis) && ableDash() && canDash)
        {
            StartCoroutine(DashCoroutine());
            
        }

        anim.SetBool("isDashing", isDashing);

    }

    private bool ableDash()
    {
        return Physics2D.OverlapCircle(dashCheck.position, 0.2f, groundLayer);
    }

    private IEnumerator DashCoroutine()
    {
        StartCoroutine(StartInvincibility());

        canDash = false;

        isDashing = true;
        rb.velocity = new Vector2(dashingPower * dir, rb.velocity.y);
        yield return new WaitForSeconds(dashingTime);
 
        rb.velocity = new Vector2(0f, rb.velocity.y);
        
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);

        canDash = true;
    }

 private IEnumerator StartInvincibility()
    {
        invincible = true;
        yield return new WaitForSeconds(IFrames);
        invincible = false;
    }

    
}
