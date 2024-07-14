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
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponent<Animator>().SetBool("isBreaking", true);
            other.gameObject.GetComponent<AudioSource>().Play();
            float delay = 1f;
            Destroy(other.gameObject, delay);
        }
    }
}
