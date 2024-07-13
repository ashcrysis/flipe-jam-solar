using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakStuff : MonoBehaviour
{
    private Dash dash;

    void Update()
    {
         dash = GetComponent<Dash>();
        var pControl = GetComponent<PlayerController>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        var pControl = GetComponent<PlayerController>();
        
        bool isJumping = !pControl.isGrounded;
        bool isBelowOtherObject = gameObject.transform.position.y < other.gameObject.transform.position.y;

       if (other.gameObject.CompareTag("breakable") && (dash.isDashing || (isJumping && isBelowOtherObject))) 
        {
            float delay = 0f;
            Destroy(other.gameObject, delay);
        }
    }
}
