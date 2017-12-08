using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robo : MonoBehaviour {


    public int vida;
    public int inteligencia;
    public int velocidade;
    public int ataque;
    public int defesa;

    private int curVida;
    private int curAtaque;
    private int curDefesa;

    public void InicializaStatus(int vid=10, int intel=10, int vel=10, int atk=10, int def=13)
    {
        vida = vid;
        inteligencia = intel;
        velocidade = vel;
        ataque = atk;
        defesa = def;

        curVida = vida;
        curAtaque = ataque;
        curDefesa = defesa;
    }

    public int getAtaque()
    {
        return curAtaque;
    }

    public int TakeDamage(int damage)
    {
        Random.InitState(546);
        if( Random.Range(0, 70) >= velocidade)
        {
            //ACERTOU!
            if (damage > curDefesa)
            {
                curVida -= (damage - curDefesa);
                return (damage - curDefesa);
            }
        }
        return 0;
    }

    public bool isDead()
    {
        return (curVida <= 0);
    }

    public int getCurVida()
    {
        return curVida;
    }

    public int getMaxVida()
    {
        return vida;
    }

    public int getVelocidade() {
        return velocidade;
    }
}
