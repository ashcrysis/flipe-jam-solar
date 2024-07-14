using System.Collections;
using UnityEngine;

public class hotAir : MonoBehaviour
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
                Debug.Log("dealt damage");
                StartCoroutine(resetCanDamage(hitDelay));
            }
        }
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
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
