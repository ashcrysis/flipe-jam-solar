using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject closestPlayer;
    public bool foundPlayer = false;
    public float enemyPatrolSpeed;
    public float enemyFollowSpeed;
    public Transform pointA;
    public Transform pointB;    
    private Rigidbody2D rb;
    private float distanceToClosestPlayer;
    private bool movingToPointA = true;
    private bool followingPlayer = false;
    private bool playerSpawned = false;
    private bool hasRun = false;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 0 && !hasRun)
        {
            playerSpawned = true;
            hasRun = true;
        }
        
        if (playerSpawned)
        {
            closestPlayer = GetClosestPlayer(players);
            if (closestPlayer != null)
            {
                foundPlayer = GetComponentInChildren<EnemyVision>().foundPlayer;
                distanceToClosestPlayer = Vector2.Distance(rb.position, closestPlayer.transform.position);
            }
        }
    }

    void FixedUpdate()
    {
        if (playerSpawned && closestPlayer != null)
        {
            if (IsGrounded())
            {
                if (foundPlayer || distanceToClosestPlayer < 1)
                {
                    MoveTowards(closestPlayer.transform.position);
                    followingPlayer = true;
                }
                else
                {
                    Patrol();
                    followingPlayer = false;
                }
            }
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    void Patrol()
    {
        if (!foundPlayer)
        {
            if (movingToPointA)
            {
                MoveTowards(new Vector2(pointA.position.x, rb.position.y));

                if (Vector2.Distance(rb.position, pointA.position) < 2f)
                {
                    movingToPointA = false;
                }
            }
            else
            {
                MoveTowards(new Vector2(pointB.position.x, rb.position.y));

                if (Vector2.Distance(rb.position, pointB.position) < 2f)
                {
                    movingToPointA = true;
                }
            }
        }
    }

    void MoveTowards(Vector2 target)
    {
        float direction = target.x - rb.position.x;
        direction = Mathf.Sign(direction); 
        if (!foundPlayer)
        {
            rb.velocity = new Vector2(direction * enemyPatrolSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(direction * enemyFollowSpeed, rb.velocity.y);
        }
        if (direction != 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * direction, transform.localScale.y, transform.localScale.z);
        }
    }

    GameObject GetClosestPlayer(GameObject[] players)
    {
        GameObject closest = null;
        float minDistance = Mathf.Infinity;
        foreach (GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < minDistance)
            {
                closest = player;
                minDistance = distance;
            }
        }
        return closest;
    }
}
