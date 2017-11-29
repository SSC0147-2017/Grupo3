using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public Text HPText;
    public int maxHP = 10;
    public int curHP = 10;

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if (curHP <= 0)
        {
            HPText.text = " " + 0;
            //TODO kill enemy
        }
        else
        {
            HPText.text = " " + curHP;
        }

    }
}
