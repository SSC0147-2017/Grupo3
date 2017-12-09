using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robo : MonoBehaviour {


    private int vida;
    private int velocidade;
    private int ataque;
    private int defesa;

    private int curVida;
    private int curAtaque;
    private int curDefesa;
    private int curVelocidade;

    public void InicializaStatus(int vid=10, int vel=10, int atk=10, int def=10)
    {
        vida = vid;
        velocidade = vel;
        ataque = atk;
        defesa = def;

        curVida = vida;
        curAtaque = ataque;
        curDefesa = defesa;
        curVelocidade = velocidade;
    }
    // Apos a batalha todos os valores de atributos do beta voltam para seu valor original
    public void RecarregaAtributos() {
        curVida = vida;
        curAtaque = ataque;
        curDefesa = defesa;
        curVelocidade = velocidade;
    }

    public int TakeDamage(int damage)
    {
        // Debug.Log("Entrou TakeDamage");
        Random.InitState(546);
        if( Random.Range(0, 60) >= velocidade)
        {
            //ACERTOU!
            if (damage > curDefesa)
            {
                curVida -= (damage - curDefesa);
                // Debug.Log("deu dano = "+ (damage - curDefesa));
                return damage - curDefesa;
            }
        }
        return 0;
    }

    public int ReduceVelocity(int reducao)
    {
        curVelocidade -= reducao;
        if (curVelocidade < 3)
        {
            curVelocidade = 3;
        }
        return curVelocidade;
    }

    public int GetAtaque()
    {
        return curAtaque;
    }

    public bool IsDead()
    {
        return (curVida <= 0);
    }

    public int GetCurVida()
    {
        return curVida;
    }

    public int GetMaxVida()
    {
        return vida;
    }

    public int GetMaxVelocidade() {
        return velocidade;
    }

    public int GetCurVelocidade()
    {
        return curVelocidade;
    }
}
