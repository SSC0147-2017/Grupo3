using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : Utilities
{

    public GameObject enemyGO;
    private GameObject betaGO;
    public GameObject screen;

    public Text betaVidaText;
    public Text enemyVidaText;
    public Text battleEvents;

    public Button ataqueBasicoButton;
    public Button ataqueSecundarioButton;
    public Button ataqueTerciarioButton;

    private Enemy enemy;
    private Player beta;

    private bool acertou;

    enum TURNOS
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
        StartCoroutine(FadeOut(screen));
        enemy = enemyGO.GetComponent<Enemy>();
        betaGO = GameObject.Find("Beta");
        beta = betaGO.GetComponent<Player>();
        enemyVidaText.text = " " + enemy.GetCurVida();
        betaVidaText.text = " " + beta.GetCurVida();
        battleEvents.text = "";
        turnoAtual = TURNOS.START;
        Random.InitState((int)Time.time);
    }

    private void Update()
    {       
        Debug.Log(turnoAtual);
        switch (turnoAtual)
        {
            case TURNOS.START:
                beta.RecarregaAtributos();
                if (beta.GetCurVelocidade() + Random.Range(0,5) >= enemy.GetCurVelocidade() + Random.Range(0,5)) {
                    turnoAtual = TURNOS.PLAYER_TURN;
                    battleEvents.text = "O Beta ataca primeiro!";
                } else {
                    turnoAtual = TURNOS.ENEMY_TURN;
                    battleEvents.text = "O inimigo ataca primeiro!";
                }

            break;
            case TURNOS.PLAYER_TURN:
                if (Input.GetMouseButtonDown(0))
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
