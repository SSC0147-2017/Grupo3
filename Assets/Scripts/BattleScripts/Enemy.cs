using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public Text vidaText;

    public int vida;
    public int inteligencia;
    public int velocidade;
    public int ataque;
    public int defesa;

    private int curVida;
    private int curInteligencia;
    private int curVelocidade;
    private int curAtaque;
    private int curDefesa;

    private void Awake()
    {
        curVida = vida;
        curInteligencia = inteligencia;
        curVelocidade = velocidade;
        curAtaque = ataque;
        curDefesa = defesa;
    }

    public void TakeDamage(int damage)
    {
        curVida -= damage;
        if (curVida <= 0)
        {
            vidaText.text = " " + 0;
            //TODO kill enemy
        }
        else
        {
            vidaText.text = " " + curVida;
        }

    }

    public bool isDead()
    {
        return (curVida <= 0);
    }
}
