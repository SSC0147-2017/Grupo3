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

    public void InicializaStatus (int vid=10, int vel=10, int atk=10, int def=10)
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
    public void RecarregaAtributos () {
        curVida = vida;
        curAtaque = ataque;
        curDefesa = defesa;
        curVelocidade = velocidade;
    }

    public bool TakeDamage (int damage)
    {
        Random.InitState((int)Time.time);
        if( Random.Range(0, 50) >= velocidade)
        {
            //ACERTOU!
            if (damage > curDefesa)
            {
                curVida -= (damage - curDefesa);
                return true;
            }
            
        }
        return false;
    }

    public void ReduceVelocity (int reducao)
    {
        curVelocidade -= reducao;
        if (curVelocidade < 3)
        {
            curVelocidade = 3;
        }
    }

    public void AumentarDefesa (int aumento)
    {
        curDefesa += aumento;
        if (curDefesa > defesa + 3)
        {
            curDefesa = defesa + 3;
        }
    }

    public int GetAtaque ()
    {
        return curAtaque;
    }

    public bool IsDead ()
    {
        return (curVida <= 0);
    }

    public int GetCurVida ()
    {
        return curVida;
    }

    public int GetMaxVida ()
    {
        return vida;
    }

    public int GetMaxVelocidade ()
    {
        return velocidade;
    }

    public int GetCurVelocidade ()
    {
        return curVelocidade;
    }
}
