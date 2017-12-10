using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : Utilities {

    public GameObject screen;
    public Canvas credits;

    public Image imageStartSelect;
    public Image imageCreditsSelect;
    public Image imageExitSelect;

    private int posicaoAtual;

    // Use this for initialization
    void Awake () {
        credits.enabled = false;
        imageStartSelect.enabled = true;
        imageCreditsSelect.enabled = false;
        imageExitSelect.enabled = false;
        posicaoAtual = 0;
	}
	
	// Update is called once per frame
	void Update () {
		switch (posicaoAtual)
        {
            case 0:
                posicaoAtual = NavegaMenu(0);
                if (Input.GetKeyDown(KeyCode.Z))
                    StartGame();
            break;
            case 1:
                posicaoAtual = NavegaMenu(1);
                if (Input.GetKeyDown(KeyCode.Z))
                    ShowCredits();
            break;
            case 2:
                posicaoAtual = NavegaMenu(2);
                if (Input.GetKeyDown(KeyCode.Z))
                    QuitGame();
            break;
        }
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

    public int NavegaMenu (int atual)
    {
        if (atual == 0)
        {
            imageStartSelect.enabled = true;
            imageCreditsSelect.enabled = false;
            imageExitSelect.enabled = false;
        }
        else if (atual == 1)
        {
            imageStartSelect.enabled = false;
            imageCreditsSelect.enabled = true;
            imageExitSelect.enabled = false;
        }
        else if (atual == 2)
        {
            imageStartSelect.enabled = false;
            imageCreditsSelect.enabled = false;
            imageExitSelect.enabled = true;
        }

        int prox;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            prox = atual - 1;
            if (prox < 0)
                prox = 2;
            return prox;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            prox = atual + 1;
            if (prox > 2)
                prox = 0;
            return prox;
        }

        return atual;
    }
}
