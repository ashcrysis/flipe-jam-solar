using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Healthpoints : MonoBehaviour
{
    public int HP = 3;

    void Update()
    {
        if (HP <= 0)
        {
            //lógica de morte aqui
            SceneManager.LoadScene(0); 
        }
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    public void HealHP(int heal)
    {
        if (HP + heal <= 3)
        {
            HP += heal;
        }
    }
}
