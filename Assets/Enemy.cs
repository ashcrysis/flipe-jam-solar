using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    private bool canDamage = true;
    private bool isColliding;
    public float hitDelay = 1f;
    public GameObject player = null;
    void Update()
    {
      if (player != null && canDamage)
      {
         var hp = player.gameObject.GetComponent<Healthpoints>();
            if (!player.gameObject.GetComponent<Dash>().invincible)
            {
                hp.TakeDamage(damage);
                canDamage = false;
                StartCoroutine(resetCanDamage(hitDelay));
            }
      }
    }
  void OnCollisionEnter2D(Collision2D other)
  {
        if (other.gameObject.CompareTag("Player") )
        {
            player = other.gameObject;
        }
  }
    void OnCollisionExit2D(Collision2D other)
  {
        if (other.gameObject.CompareTag("Player") && !canDamage)
        {
            player = null;
        }
  }
  IEnumerator resetCanDamage(float hitDelay)
  {
    yield return new WaitForSeconds(hitDelay);
    canDamage = true;
  }
}
