using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour {

    public float vida;
    public Texture Sangue, Contorno;
    public int VidaCheia = 100;

	// Use this for initialization
	void Start () {
        vida = VidaCheia;
        
	}
	
	// Update is called once per frame
	void Update () {
		if(vida >= VidaCheia)
        {
            vida = VidaCheia;
        }

        else if (vida <= 0)
        {
            vida = 0;
        }
	}

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 25, Screen.height / 15, Screen.width / 5.5f/VidaCheia*vida, Screen.height / 20), Contorno);
        GUI.DrawTexture(new Rect(Screen.width / 40, Screen.height / 40, Screen.width / 5, Screen.height / 8), Contorno);
    }
}
