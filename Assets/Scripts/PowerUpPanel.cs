using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PowerUpEffect = System.Collections.Generic.KeyValuePair<PowerUpType, int>;

public class PowerUpPanel : MonoBehaviour {

    public GameObject menuItemPrefab;
    public Player player;

    // Slot de power up que chamou o painel e seu respectivo tipo
    public GameObject slotIcon;
    public PowerUpType type;

    // Posiçao do ultimo power up ativo para esse tipo
    int lastActivePowerUp;

	// Use this for initialization
	void Start () {
		
	}
	
	private void OnEnable () {
        // Desativa os botoes dos slots de power up que abriu o painel
        int i = 0;
        foreach (Button button in this.transform.parent.GetComponentsInChildren<Button>()) {
            if (i != 0)
                button.interactable = false;
            i++;
        }

        // Lista os power ups do mesmo tipo do slot que abriu o painel
        bool hasPowerUp = false;
        for (i = 0; i < player.PowerUpCount; i++) {
            PowerUp powerUp = player.getPowerUp(i);

            // Confere se o power up e do mesmo tipo do slot
            if (powerUp.Type != type)
                continue;

            // Cria o item do menu para mostrar o power up
            hasPowerUp = true;
            GameObject newMenuItem = Instantiate(menuItemPrefab);            

            // Carrega o icone do power up
            Image icon = newMenuItem.transform.GetChild(0).GetChild(0).GetComponent<Image>();
            icon.sprite = powerUp.Icon;

            string description = "";

            // Carrega a descricao do power up (nome + efeitos + penalidades)
            description = powerUp.Name + " (";
            foreach (PowerUpEffect effect in powerUp.Effects) {
                description += effect.Key.ToString() + "+" + effect.Value;
                if (!effect.Equals(powerUp.Effects[powerUp.Effects.Count-1]))
                    description += ", ";
            }                

            foreach (PowerUpEffect penalty in powerUp.Penalties) {
                description += ", ";
                description += penalty.Key.ToString() + "-" + penalty.Value;
                if (!penalty.Equals(powerUp.Penalties[powerUp.Penalties.Count-1]))
                    description += ", ";
            }
            description += ")";
                
            newMenuItem.GetComponentInChildren<Text>().text = description;

            // Chama a funcao quando clicar no item do menu para efetivar o power up 
            int aux = i;
            newMenuItem.GetComponentInChildren<Button>().onClick.AddListener(() => applyItem(aux));

            // Se esse for o power up ativo, habilita o botao para desativa-lo
            if (powerUp.Active) {
                newMenuItem.transform.GetChild(2).gameObject.SetActive(true);
                newMenuItem.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => removeItem(aux));
            }

            // Adiciona o novo item ao painel
            newMenuItem.transform.SetParent(this.gameObject.transform);
        }

        // Se nenhum power up desse tipo foi encontrado, mostra mensagem
        if (!hasPowerUp)
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnDisable() {
        // Reabilita botoes ao fechar o painel
        foreach (Button button in this.transform.parent.GetComponentsInChildren<Button>())
            button.interactable = true;

        // Destroi items criados ao abrir o painel
        foreach (Transform child in gameObject.transform) {
            if (child.GetSiblingIndex() == 0)
                child.gameObject.SetActive(false);
            else
                Destroy(child.gameObject);
        }
    }

    /* Efetiva item escolhido */
    public void applyItem(int pos) {
        Debug.Log(pos);
        PowerUp powerUp = player.getPowerUp(pos);

        // Ativa a imagem do slot
        slotIcon.SetActive(true);

        // Atualiza o icone do slot
        slotIcon.GetComponent<Image>().sprite = powerUp.Icon;

        // Remove power up ativo anterior, se houver
        PowerUp currentActive = player.getActivePowerUp(powerUp.Type);
        if (currentActive != null)
            currentActive.Active = false;

        // Seta como power up  ativo
        powerUp.Active = true;

        // Fecha painel
        this.gameObject.SetActive(false);
    }

    public void removeItem(int pos) {
        Debug.Log(pos);
        PowerUp powerUp = player.getPowerUp(pos);

        // Desativa a imagem do slot
        slotIcon.SetActive(false);

        // Desabilita o power up
        powerUp.Active = false;

        // Fecha painel
        this.gameObject.SetActive(false);
    }

	public void OnClick () {
        // Se clicar fora do painel, fecha ele
		if (this.gameObject.activeSelf && 
             !RectTransformUtility.RectangleContainsScreenPoint(
                 this.gameObject.GetComponent<RectTransform>(), 
                 Input.mousePosition, 
                 Camera.main)) {                
            this.gameObject.SetActive(false);
         }
	}
}
