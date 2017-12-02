using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    private bool controle = false;

    void pausa()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (controle == false)
            {
                Time.timeScale = 0;
                controle = true;
            }

            else
            {
                Time.timeScale = 1;
                controle = false;
            }
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pausa();
	}
}
