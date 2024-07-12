using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakStuff : MonoBehaviour
{
    private bool canBreakStuff = false;
    void Update()
    {
        var dash = GetComponent<Dash>();
        var pControl = GetComponent<PlayerController>();
        canBreakStuff = dash.invincible || !pControl.isGrounded ;
    }
     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("breakable") && canBreakStuff && gameObject.transform.position.y < other.gameObject.transform.position.y) 
        {
            float delay = 0f;
            Debug.Log("tentou quebrar");
            // inserir efeitos visuais e troca de animação do negocio quebrado aqui
            Destroy(other.gameObject, delay);
        }    
    }
}
