﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PowerUpEffect = System.Collections.Generic.KeyValuePair<PowerUpType, int>;
using UnityEngine.SceneManagement;

public class Player : Robo {
	List<PowerUp> powerUps;

    private void Awake()
    {
		InicializaStatus(10, 10, 10, 10);

        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(this.gameObject);
        }
    }


    void Start () {
		powerUps = new List<PowerUp>();

        // DEBUG -------------->
        // Powerup bateria de lítio
		PowerUpEffect effect = new PowerUpEffect(PowerUpType.Vida, 3);
		PowerUpEffect penalty = new PowerUpEffect(PowerUpType.Velocidade, 1);

        List<PowerUpEffect> effectList = new List<PowerUpEffect>();
        List<PowerUpEffect> penaltyList = new List<PowerUpEffect>();

        effectList.Add(effect);
        penaltyList.Add(penalty);

        PowerUp newPowerUp = new PowerUp("Bateria de lítio", PowerUpType.Vida, effectList, penaltyList);
        newPowerUp.Icon = Resources.Load<Sprite>("Sprites/battery");
		powerUps.Add(newPowerUp);

        // Snapdragon powerup
        effectList = new List<PowerUpEffect>();
        penaltyList = new List<PowerUpEffect>();
        effect = new PowerUpEffect(PowerUpType.Inteligencia, 5);
        effectList.Add(effect);
        effect = new PowerUpEffect(PowerUpType.Velocidade, 1);
        effectList.Add(effect);

        newPowerUp = new PowerUp("Processador Snapdragon", PowerUpType.Inteligencia, effectList, penaltyList);
        newPowerUp.Icon = Resources.Load<Sprite>("Sprites/motherBoard");
        powerUps.Add(newPowerUp);

        // Hammer powerup
        effectList = new List<PowerUpEffect>();
        penaltyList = new List<PowerUpEffect>();
        effect = new PowerUpEffect(PowerUpType.Ataque, 5);
        effectList.Add(effect);
        newPowerUp = new PowerUp("Martelo", PowerUpType.Ataque, effectList, penaltyList);
        newPowerUp.Icon = Resources.Load<Sprite>("Sprites/hammer");
        powerUps.Add(newPowerUp);

        // Flashlight powerup
        effectList = new List<PowerUpEffect>();
        penaltyList = new List<PowerUpEffect>();
        effect = new PowerUpEffect(PowerUpType.Ataque, 1);
        effectList.Add(effect);
        newPowerUp = new PowerUp("Lanterna", PowerUpType.Ataque, effectList, penaltyList);
        newPowerUp.Icon = Resources.Load<Sprite>("Sprites/lanterna");
        powerUps.Add(newPowerUp);

        // Oil can powerup
        effectList = new List<PowerUpEffect>();
        penaltyList = new List<PowerUpEffect>();
        effect = new PowerUpEffect(PowerUpType.Velocidade, 3);
        effectList.Add(effect);
        penalty = new PowerUpEffect(PowerUpType.Vida, 2);
        penaltyList.Add(penalty);
        newPowerUp = new PowerUp("Lata de óleo", PowerUpType.Velocidade, effectList, penaltyList);
        newPowerUp.Icon = Resources.Load<Sprite>("Sprites/oilCan");
        powerUps.Add(newPowerUp);

        // Gas powerup
        effectList = new List<PowerUpEffect>();
        penaltyList = new List<PowerUpEffect>();
        effect = new PowerUpEffect(PowerUpType.Vida, 1);
        effectList.Add(effect);
        effect = new PowerUpEffect(PowerUpType.Velocidade, 2);
        effectList.Add(effect);
        penalty = new PowerUpEffect(PowerUpType.Inteligencia, 1);
        penaltyList.Add(penalty);
        newPowerUp = new PowerUp("Gasolina", PowerUpType.Vida, effectList, penaltyList);
        newPowerUp.Icon = Resources.Load<Sprite>("Sprites/gasoline");
        powerUps.Add(newPowerUp);
        // --------------> DEBUG
    }


    /* Retorna a quantidade de power ups que o player tem */
    public int PowerUpCount {
		get {
			return powerUps.Count;
		}
	}

    /* Retorna o power up na posicao pos */
	public PowerUp getPowerUp(int pos) {
		return powerUps[pos];
	}

    /* Retornar o power up ativo de um dado tipo */
    public PowerUp getActivePowerUp(PowerUpType type) {
        foreach (PowerUp powerUp in powerUps) {
            if (powerUp.Type == type)
                return powerUp;
        }
        return null;
    }
}
