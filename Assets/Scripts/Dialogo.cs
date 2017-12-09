using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour {
    public GameObject panelBox;
    public TextAsset arquivo;
    public string[] texto;
    public Text textoMensagem;
    private int EndLine;
    private int CurrentLine;
    public bool ativo;

	// Use this for initialization
	void Start () {
	    if(arquivo != null)
        {
            texto = (arquivo.text.Split('\n'));
        }
        
        if (EndLine == 0)
        {
            EndLine = texto.Length;
        }

        desabilitar();
	}
	
	// Update is called once per frame
	void Update () {
        habilitar();

		if(Input.GetKeyDown("z"))
        {
            if(CurrentLine < EndLine)
            {
                textoMensagem.text = texto[CurrentLine];
            }

            if(panelBox.activeSelf)
            {
                CurrentLine += 1;
            }
        }

        if (CurrentLine > EndLine)
        {
            CurrentLine = 0;
            desabilitar();
        }
	}

    void habilitar()
    {
        if (Input.GetKeyDown("z"))
        {
            panelBox.SetActive(true);
        }
    }

    void desabilitar()
    {
            panelBox.SetActive(false);
        
    }
}
