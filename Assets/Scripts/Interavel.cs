using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interavel : MonoBehaviour
{
    [SerializeField]private float minDistance;
    public bool canInteract;


    void Update()
    {
        canInteract = Vector2.Distance(transform.position,GameObject.FindGameObjectWithTag("Player").transform.position) < minDistance;
    }

}
