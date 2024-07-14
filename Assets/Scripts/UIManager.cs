using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text hpText;
    private int hp;

    // Start is called before the first frame update
    void Start()
    {
      // var healt = GameObject.FindGameObjectWithTag("Player").GetComponent<Healthpoints>();
       //hp = healt.HP;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "Vida: "+ hp;
    }
}
