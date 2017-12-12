using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    public GameObject panelBox;
    public TextAsset arquivo;
    public string texto;
    public Text textoMensagem;
    private int EndLine;
    private int CurrentLine;
    public bool ativo = false;

    // Use this for initialization
    void Start()
    {

        desabilitar();
    }

    // Update is called once per frame
    void Update()
    {
        //desabilitar();
        if (Input.GetKeyDown("x"))
        {
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

    void OnTriggerStay2D(Collider2D other)
    {

        if (Input.GetKeyDown("z"))
        {
            habilitar();

            if (other.gameObject.CompareTag("menina1"))
            {
                textoMensagem.text = "Hallo!aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\n";
            }

            else
            {
                textoMensagem.text = "Hola!";
            }

        }



        //desabilitar();


    }
}
