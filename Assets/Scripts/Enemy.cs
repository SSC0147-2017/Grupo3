﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Robo {

    private int type;

    private void Awake()
    {
        // Debug.Log("instanciou inimigo");
        InicializaStatus(15);
    }
}
