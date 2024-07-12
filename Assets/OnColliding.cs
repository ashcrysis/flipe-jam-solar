using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColliding : MonoBehaviour
{
    public LayerMask layer;
  void OnTriggerEnter2D(Collider2D other)
  {
        if (other.gameObject.layer == layer || other.gameObject.CompareTag("Player"))
        {
          Destroy(gameObject,0.2f);
        }
  }

}
