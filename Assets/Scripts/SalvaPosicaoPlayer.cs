using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SalvaPosicaoPlayer : MonoBehaviour {

    string nomeCenaAtual;
    void Awake()
    {
        nomeCenaAtual = SceneManager.GetActiveScene().name;
    }
	// Use this for initialization
	void Start () {
       if(PlayerPrefs.HasKey(nomeCenaAtual + "X") && PlayerPrefs.HasKey(nomeCenaAtual + "Y") && PlayerPrefs.HasKey(nomeCenaAtual + "Z"))
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat(nomeCenaAtual + "X"), PlayerPrefs.GetFloat(nomeCenaAtual + "Y"), PlayerPrefs.GetFloat(nomeCenaAtual + "Z"));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SalvarLocalizacao()
    {
        PlayerPrefs.SetFloat(nomeCenaAtual + "X", transform.position.x);
        PlayerPrefs.SetFloat(nomeCenaAtual + "Y", transform.position.y);
        PlayerPrefs.SetFloat(nomeCenaAtual + "Z", transform.position.z);
    }
}
