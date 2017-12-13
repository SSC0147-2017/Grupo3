using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : Utilities
{
    public GameObject enemyGO; //   GameObject do inimigo do jogador
    public GameObject betaGO;  //  GameObject do robo do jogador, o Beta
    public GameObject screen; //    Imagem preta que cobre a tela, por padrao ela esta com alpha 0,
                              //    mas ao se realizar fadein/fadeout o valor do alpha é gradativamente trocado

    public Text betaVidaText;   //Texto na cena com a vida atual do beta
    public Text enemyVidaText;  //Texto na cena com a vida do inimigo
    public Text battleEvents;   //Texto que descreve as açoes realizadas durante o combate

    //public Button ataqueBasicoButton;   //Botao do primeiro ataque do beta
    //public Button ataqueSecundarioButton;   //Botao do segundo ataque do beta
    //public Button ataqueTerciarioButton;    //Botao do terceiro ataque do beta

    public Image ataque0_select;
    public Image ataque1_select;
    public Image ataque2_select;


    private Enemy enemy;    //Instancia do inimigo
    public Player beta;    //Instancia do beta


    private int ataqueSelecionado;
    private bool acertou;   //Esta variavel vai armazenar se o Beta acertou, ou não, o golpe.
                            //  Serve para decidir qual texto apresentar no "battleEvents".

    private bool pressedButton; //  Indica se o jogador apertou alguma das opcoes de ataque

    enum TURNOS //Possiveis estados da maquina de estados que controla as etapas do combate
    {
        START,
        PLAYER_TURN,
        ENEMY_TURN,
        WIN,
        LOSE
    }

    TURNOS turnoAtual;

    private void Awake()
    {
        StartCoroutine(FadeOut(screen));//  Realiza o Fade ao entrar na cena de combate
        enemy = enemyGO.GetComponent<Enemy>();
        betaGO = GameObject.Find("Beta");
        beta = betaGO.GetComponent<Player>();

        ataqueSelecionado = 0;
        ataque0_select.enabled = true;
        ataque1_select.enabled = false;
        ataque2_select.enabled = false;

        enemyVidaText.text = enemy.GetMaxVida() + " / " + enemy.GetMaxVida(); //   Inicializa textos da cena que mostram a vida atual tanto do beta quanto do inimigo
        betaVidaText.text = beta.GetMaxVida() + " / " + beta.GetMaxVida();
        battleEvents.text = "Teste";
        pressedButton = false;
        Random.InitState((int)Time.time);   //gera semente para valores randomicos
        turnoAtual = TURNOS.START;
    }

    private void Update()
    {       
        Debug.Log(turnoAtual);
        switch (turnoAtual)
        {
            case TURNOS.START:
                beta.RecarregaAtributos(); //Recarrega todos os atributos (cur..) para seu valor maximo, por exemplo, curVida = maxVida.
                //   Decide se o inimigo ou o beta vai comecar a batalha
                if (beta.GetCurVelocidade() + Random.Range(0,5) >= enemy.GetCurVelocidade() + Random.Range(0,5)) {
                    turnoAtual = TURNOS.PLAYER_TURN;
                    battleEvents.text = "O Beta ataca primeiro!";
                } else {
                    turnoAtual = TURNOS.ENEMY_TURN;
                    battleEvents.text = "O inimigo ataca primeiro!";
                }

            break;
            case TURNOS.PLAYER_TURN:
                Debug.Log(ataqueSelecionado);
                switch (ataqueSelecionado)
                {
                    case 0:
                        ataqueSelecionado = NavegaAtaques(0);
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Ataque0Selected();
                            turnoAtual = TURNOS.ENEMY_TURN;
                        }
                    break;
                    case 1:
                        ataqueSelecionado = NavegaAtaques(1);
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Ataque1Selected();
                            turnoAtual = TURNOS.ENEMY_TURN;
                        }
                    break;
                    case 2:
                        ataqueSelecionado = NavegaAtaques(2);
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Ataque2Selected();
                            turnoAtual = TURNOS.ENEMY_TURN;
                        }
                    break;

                }
                if (enemy.IsDead())
                {
                    turnoAtual = TURNOS.WIN;
                    enemyVidaText.text = "0 / " + enemy.GetMaxVida();
                }
                else
                {
                    enemyVidaText.text = enemy.GetCurVida() + " / " + enemy.GetMaxVida();
                }


            break;
            case TURNOS.ENEMY_TURN:

                StartCoroutine(espera());
                
            break;
            case TURNOS.WIN:
                battleEvents.text = "Beta venceu! Pressione qualquer tecla para continuar...";
                if (Input.anyKey)
                {
                    StartCoroutine(FadeIn(screen, "Icmc"));
                }
            break;
            case TURNOS.LOSE:
                battleEvents.text = "Beta foi derrotado! Pressione qualquer tecla para continuar...";
                if (Input.anyKey)
                {
                    StartCoroutine(FadeIn(screen, "Icmc"));
                }
            break;

        }
    }

    IEnumerator espera()
    {
        yield return new WaitForSeconds(1.0f);
        battleEvents.text = "O inimigo atacou!";
        beta.TakeDamage(Random.Range(0, 5) + enemy.GetAtaque());

        turnoAtual = TURNOS.PLAYER_TURN;
        if (beta.IsDead())
        {
            turnoAtual = TURNOS.LOSE;
            betaVidaText.text = "0 / " + beta.GetMaxVida();
        }
        else
        {
            betaVidaText.text = beta.GetCurVida() + " / " + beta.GetMaxVida();
        }
    }

    private void Ataque0Selected ()
    {
        Debug.Log("atacou com 0");
        battleEvents.text = "Beta usou ataque basico!";
        acertou = enemy.TakeDamage(Random.Range(0,5) + beta.GetAtaque());
        ChecaAcerto(acertou);
    }

    private void Ataque1Selected ()
    {
        Debug.Log("atacou com 1");
        enemy.ReduceVelocity(1);
        battleEvents.text = "A velocidade do inimigo foi reduzida!";
    }

    private void Ataque2Selected ()
    {
        Debug.Log("atacou com 2");
        beta.AumentarDefesa(1);
        battleEvents.text = "Beta aumentou a propria defesa!";
    }

    private void ChecaAcerto (bool hit)
    {
        if (hit)
        {
            battleEvents.text = "Beta acertou!";
        }
        else
        {
            battleEvents.text = "Beta errou!";
        }
    }


    public int NavegaAtaques (int ataqueAtual)
    {
        if (ataqueAtual == 0)
        {
            ataque0_select.enabled = true;
            ataque1_select.enabled = false;
            ataque2_select.enabled = false;
        }
        else if (ataqueAtual == 1)
        {
            ataque0_select.enabled = false;
            ataque1_select.enabled = true;
            ataque2_select.enabled = false;
        }
        else if (ataqueAtual == 2)
        {
            ataque0_select.enabled = false;
            ataque1_select.enabled = false;
            ataque2_select.enabled = true;
        }

        int proximo;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            proximo = ataqueAtual - 1;
            if (proximo == -1)
                proximo = 2;
            return proximo;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            proximo = ataqueAtual + 1;
            if (proximo == 3)
                proximo = 0;
            return proximo;
        }
        return ataqueAtual;

    }
}
