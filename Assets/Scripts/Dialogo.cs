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
    private int count = 0;

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
                if (count == 0)
                {
                    textoMensagem.text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                    count++;
                }

                else if (count == 1)
                {
                    textoMensagem.text = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
                    count = -1;
                }

                else if (count == -1)
                {
                    desabilitar();
                    count = 0;
                }


            }

            else if (other.gameObject.CompareTag("menina2"))
            {
                if (count == 0)
                {
                    textoMensagem.text = "Hola!";
                    count = -1;
                }

                else if (count == -1)
                {
                    desabilitar();
                    count = 0;
                }

            }



        }

    }

    void dialInicial()
    {
        if (count == 0)
        {
            textoMensagem.text = "Alguém sabotou nossa oficina. Preciso que você me ajude a descobrir o que aconteceu.";
            count++;
        }

        else if (count == 1)
        {
            textoMensagem.text = "Beta foi o único que permaneceu aqui. Leve-o com você e veja se há algo suspeito nas proximidades";
            count++;
        }

        else if (count == 2)
        {
            textoMensagem.text = "Você obteve Beta!";
            count++;
        }

        else if (count == 3)
        {
            textoMensagem.text = "Simões: Ele possui um banco de dados com todas as informações dos robôs desaparecidos.";
            count++;
        }

        else if (count == 4)
        {
            textoMensagem.text = "Beta: Olá, vou te ajudar a resolver esse mistério, mas antes, algumas dicas básicas…";
            count++;
        }

        else if (count == 5)
        {
            textoMensagem.text = "Utilize as setas do teclado para se movimentar.";
            count++;
        }

        else if (count == 6)
        {
            textoMensagem.text = "Também é possível utilizar as teclas W/S A/D para se movimentar na vertical e na horizontal respectivamente.";
            count++;
        }

        else if (count == 7)
        {
            textoMensagem.text = "Utilize Z para interagir com objetos e pessoas ou para selecionar opções em menus.";
            count++;
        }

        else if (count == 8)
        {
            textoMensagem.text = "Utiliza X para voltar para as seleções anteriores.";
            count++;
        }

        else if (count == 9)
        {
            textoMensagem.text = "Tanto Z quanto X podem ser utilizados para o diálogo ser mais rápido.";
            count++;
        }

        else if (count == 10)
        {
            textoMensagem.text = "Por fim, utilize M para abrir o menu.";
            count++;
        }

        else if (count == 11)
        {
            textoMensagem.text = "É hora de começarmos nossa aventura!";
            count = -1;
        }

        else if (count == -1)
        {
            desabilitar();
            count = 0;
        }
    }
}
