using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PowerUpSlot : MonoBehaviour {

	public GameObject itemPanel;

	// Use this for initialization
	void Start () {
		
	}

    // Abre painel para escolher power up
    // Se for botao de voltar, carrega a ultima cena
	public void OnClick (int type) {
        if (type == -1) {
            // TODO: Carregar a ultima cena
            SceneManager.LoadScene("Icmc");
            return;
        }

        // Seta o tipo de item a ser exibido e abre o painel de itens
        itemPanel.GetComponent<PowerUpPanel>().type = (PowerUpType) type;
        itemPanel.GetComponent<PowerUpPanel>().slotIcon = this.transform.GetChild(0).gameObject;
        itemPanel.SetActive(true);
    }
}
