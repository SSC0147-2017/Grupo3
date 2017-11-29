using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour {

    //public Button basicAttackButton;
    public Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    public void BasicAttack()
    {
        enemy.TakeDamage(1);
    }

}

