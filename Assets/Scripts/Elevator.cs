using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform starterPosition;
    public Transform endPosition;
    private Rigidbody2D rb;
    public float elevatorSpeed;
    public Transform destiny;
    private SpriteRenderer spriteRenderer;
    public Sprite elevatorOff;
    public Sprite elevatorOn;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        destiny = starterPosition;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, destiny.position, elevatorSpeed * Time.fixedDeltaTime));
    }

    private void Update() {
        if(rb.position.y != destiny.position.y){
            spriteRenderer.sprite = elevatorOn;
        }else{
            spriteRenderer.sprite = elevatorOff;
        }
    }
}
