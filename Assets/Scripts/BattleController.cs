using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : Utilities
{

    public GameObject enemyGO; //   GameObject do inimigo do jogador
    private GameObject betaGO;  //  GameObject do robo do jogador, o Beta
    public GameObject screen; //    Imagem preta que cobre a tela, por padrao ela esta com alpha 0,
                              //    mas ao se realizar fadein/fadeout o valor do alpha é gradativamente trocado

    public Text betaVidaText;   //Texto na cena com a vida atual do beta
    public Text enemyVidaText;  //Texto na cena com a vida do inimigo
    public Text battleEvents;   //Texto que descreve as açoes realizadas durante o combate

    public Button ataqueBasicoButton;   //Botao do primeiro ataque do beta
    public Button ataqueSecundarioButton;   //Botao do segundo ataque do beta
    public Button ataqueTerciarioButton;    //Botao do terceiro ataque do beta

    private Enemy enemy;    //Instancia do inimigo
    private Player beta;    //Instancia do beta

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
        enemyVidaText.text = " " + enemy.GetCurVida(); //   Inicializa textos da cena que mostram a vida atual tanto do beta quanto do inimigo
        betaVidaText.text = " " + beta.GetCurVida();
        battleEvents.text = "";
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
                if (pressedButton)
                {
                    
                    ataqueBasicoButton.onClick.AddListener(AtaqueBasicoOnButtonClick);
                    ataqueSecundarioButton.onClick.AddListener(AtaqueSecundarioOnButtonClick);
                    ataqueTerciarioButton.onClick.AddListener(AtaqueTerciarioOnButtonClick);
                }
            break;
            case TURNOS.ENEMY_TURN:
                battleEvents.text = "O inimigo atacou!";
                beta.TakeDamage(Random.Range(0, 5) + enemy.GetAtaque());

                turnoAtual = TURNOS.PLAYER_TURN;
                if (beta.IsDead())
                {
                    turnoAtual = TURNOS.LOSE;
                    betaVidaText.text = "0 / "+beta.GetMaxVida();
                }
                else
                {
                    betaVidaText.text = beta.GetCurVida()+" / "+beta.GetMaxVida();
                }
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

    private void AtaqueBasicoOnButtonClick ()
    {
        battleEvents.text = "Beta usou ataque basico!";
        acertou = enemy.TakeDamage(Random.Range(0,5) + beta.GetAtaque());
        ChecaAcerto(acertou);
        turnoAtual = TURNOS.ENEMY_TURN;
        if (enemy.IsDead())
        {
            turnoAtual = TURNOS.WIN;
            enemyVidaText.text = "0 / "+enemy.GetMaxVida();
        }
        else
        {
            enemyVidaText.text = enemy.GetCurVida()+" / "+enemy.GetMaxVida();
        }
    }

    private void AtaqueSecundarioOnButtonClick ()
    {
        turnoAtual = TURNOS.ENEMY_TURN;
        enemy.ReduceVelocity(1);
        battleEvents.text = "A velocidade do inimigo foi reduzida!";
    }

    private void AtaqueTerciarioOnButtonClick ()
    {
        battleEvents.text = "Beta aumentou a propria defesa!";
        beta.AumentarDefesa(1);
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
}
