using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {

    //public Button basicAttackButton;
    public Enemy enemy;
    public RoboBeta beta;
    public Button button;
    private bool buttonPressed = false;

    enum TURNOS
    {
        START,
        PLAYER_TURN,
        ENEMY_TURN,
        WIN,
        LOSE
    }

    TURNOS turnoAtual;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        beta = GetComponent<RoboBeta>();
        turnoAtual = TURNOS.START;
        
    }

    private void Update()
    {
        Debug.Log(turnoAtual);
        switch (turnoAtual)
        {
            case TURNOS.START:
                turnoAtual = TURNOS.PLAYER_TURN;
                break;
            case TURNOS.PLAYER_TURN:
                button.onClick.AddListener(onButtonClick);
                if (buttonPressed == true)
                {
                    buttonPressed = false;
                    enemy.TakeDamage(1);
                    turnoAtual = TURNOS.ENEMY_TURN;
                    if (enemy.isDead())
                    {
                        turnoAtual = TURNOS.WIN;
                    }
                }    
                break;
            case TURNOS.ENEMY_TURN:
                beta.TakeDamage(1);
                turnoAtual = TURNOS.PLAYER_TURN;
                if (beta.isDead())
                {
                    turnoAtual = TURNOS.LOSE;
                }
                break;
            case TURNOS.WIN:
                break;
            case TURNOS.LOSE:
                break;

        }
    }

    void onButtonClick()
    {
        buttonPressed = true;
    }
}

