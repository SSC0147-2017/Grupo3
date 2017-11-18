using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robo : MonoBehaviour {
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

    // Use this for initialization
    void Start () {
        Debug.Log(curVida);
	}

	// Update is called once per frame
	void Update () {

	}
}
