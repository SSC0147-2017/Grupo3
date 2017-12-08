using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour {

    //public Button basicAttackButton;
    public GameObject enemyGO;
    public GameObject betaGO;
    private Enemy enemy;
    private Player beta;
    public Button button;
    private bool buttonPressed = false;
    public Text betaVidaText;
    public Text enemyVidaText;
    public Text battleEvents;

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

        beta = betaGO.GetComponent<Player>();
        enemyVidaText.text = " " + enemy.getCurVida();
        betaVidaText.text = " " + beta.getCurVida();
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
                if (beta.getVelocidade() + Random.Range(0,5) >= enemy.getVelocidade() + Random.Range(0,5)) {
                    turnoAtual = TURNOS.PLAYER_TURN;
                    battleEvents.text = "O Beta ataca primeiro!";
                } else {
                    turnoAtual = TURNOS.ENEMY_TURN;
                    battleEvents.text = "O inimigo ataca primeiro!";
                }

            break;
            case TURNOS.PLAYER_TURN:
                button.onClick.AddListener(onButtonClick);
                if (buttonPressed == true)
                {
                    buttonPressed = false;
                    enemy.TakeDamage(Random.Range(0,5) + beta.getAtaque());

                    turnoAtual = TURNOS.ENEMY_TURN;
                    if (enemy.isDead())
                    {
                        turnoAtual = TURNOS.WIN;
                        enemyVidaText.text = "0 / "+enemy.getMaxVida();
                    }
                    else
                    {
                        enemyVidaText.text = enemy.getCurVida()+" / "+enemy.getMaxVida();
                    }
                }
            break;
            case TURNOS.ENEMY_TURN:
                beta.TakeDamage(Random.Range(0, 5) + enemy.getAtaque());

                turnoAtual = TURNOS.PLAYER_TURN;
                if (beta.isDead())
                {
                    turnoAtual = TURNOS.LOSE;
                    betaVidaText.text = "0 / "+beta.getMaxVida();
                }
                else
                {
                    betaVidaText.text = beta.getCurVida()+" / "+beta.getMaxVida();
                }
            break;
            case TURNOS.WIN:

            break;
            case TURNOS.LOSE:
                battleEvents.text = "beta foi derrotado!";
                //yield WaitForSeconds (2);
                SceneManager.LoadScene("Icmc");
            break;

        }
    }

    void onButtonClick()
    {
        buttonPressed = true;
    }
}
