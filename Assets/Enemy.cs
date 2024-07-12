using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 1;
    private bool canDamage = true;
  void OnCollisionEnter2D(Collision2D other)
  {
        if (other.gameObject.CompareTag("Player") && canDamage)
        {
            var hp = other.gameObject.GetComponent<Healthpoints>();
            if (!other.gameObject.GetComponent<Dash>().invincible)
            {
                hp.TakeDamage(damage);
                canDamage = false;
            }
        }
  }
    void OnCollisionExit2D(Collision2D other)
  {
        if (other.gameObject.CompareTag("Player") && !canDamage)
        {
            canDamage = true;
        }
  }
}
