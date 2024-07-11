using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private PlayerController playerController;
    private SpriteRenderer pSpriteRenderer;
    [SerializeField]private Sprite[] sprites;
    
    //Esse código tá alterando o sprite do jogador por enquanto, mais pra frente ele tem que trocar o animator

    void Start()
    {
        /* playerController = GetComponent<PlayerController>();
        pSpriteRenderer = GetComponent<SpriteRenderer>();

        pSpriteRenderer.sprite = sprites[playerController.playerNumber-1]; */
        
    }

}
