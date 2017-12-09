using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour {

    public GameObject enemyGO;
    private GameObject betaGO;
    private Enemy enemy;
    private Player beta;
    public Text betaVidaText;
    public Text enemyVidaText;
    public Text battleEvents;
    // private bool buttonPressed = false;


    public Button ataqueBasicoButton;
    public Button ataqueSecundarioButton;


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
        enemy = enemyGO.GetComponent<Enemy>();
        betaGO = GameObject.Find("Beta");
        beta = betaGO.GetComponent<Player>();
        enemyVidaText.text = " " + enemy.GetCurVida();
        betaVidaText.text = " " + beta.GetCurVida();
        battleEvents.text = "";
        turnoAtual = TURNOS.START;
        Random.InitState(43);
    }

    private void Update()
    {
        Debug.Log(turnoAtual);
        switch (turnoAtual)
        {
            case TURNOS.START:
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
                }
            break;
            case TURNOS.ENEMY_TURN:
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
                beta.RecarregaAtributos();
                if (Input.anyKey)
                {
                    SceneManager.LoadScene("Icmc");
                }
            break;
            case TURNOS.LOSE:
                battleEvents.text = "Beta foi derrotado! Pressione qualquer tecla para continuar...";
                beta.RecarregaAtributos();
                if (Input.anyKey)
                {
                    SceneManager.LoadScene("Icmc");
                }
            break;

        }
    }

    void AtaqueBasicoOnButtonClick()
    {
        // Debug.Log("clicou em ataque basico");
        int dano = enemy.TakeDamage(Random.Range(0,5) + beta.GetAtaque());
        // Debug.Log("dano infligido = "+dano);
        battleEvents.text = "Beta usou ataque basico!";
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
        // Debug.Log("saiu do ataque basico");
    }

    void AtaqueSecundarioOnButtonClick()
    {
        turnoAtual = TURNOS.ENEMY_TURN;
        enemy.ReduceVelocity(1);
        battleEvents.text = "A velocidade do inimigo foi reduzida!";
    }
}
