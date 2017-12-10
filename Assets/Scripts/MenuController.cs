using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : Utilities {

    public GameObject screen;
    public Canvas credits;

	// Use this for initialization
	void Start () {
        credits.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame ()
    {
        StartCoroutine(FadeIn(screen, "Icmc")); //Inicia fade para a cena do ICMC
    }

    public void ShowCredits ()
    {
        credits.enabled = !credits.enabled; //Troca o estado atual dos creditos (entre mostrando e não-mostrando)
    }

    public void QuitGame ()
    {
        Application.Quit(); //NOTA: Só funciona na versao build do jogo
    }
}
