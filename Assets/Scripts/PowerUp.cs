using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PowerUpEffect = System.Collections.Generic.KeyValuePair<PowerUpType, int>;

public enum PowerUpType {
	Ataque,
	Defesa,
	Inteligencia,
	Vida,
	Velocidade
}

public class PowerUp {
    // Tipo do power up, determinado pelo seu efeito mais forte
	PowerUpType type;

    string name;
    
    // Cada power up tem uma lista de efeitos e penalidades
    // O efeito mais forte/predominante determina o tipo (type) do power up
	List<PowerUpEffect> effect;
	List<PowerUpEffect> penalty;

    // Icone associado ao power up
	Sprite icon;

    public bool Active;

	public PowerUp(string name, PowerUpType type, List<PowerUpEffect> effect, List<PowerUpEffect> penalty) {
		this.name = name;
		this.type = type;
		this.effect = effect;
		this.penalty = penalty;
        this.Active = false;       

        // Carrega os sprites referentes aos icones dos pwoer ups
        string imagePath = "";
        switch (type) {
            case PowerUpType.Inteligencia:
                imagePath = "Images/PowerUps/inteligencia";
                break;
            case PowerUpType.Vida:
                imagePath = "Images/PowerUps/vida";
                break;
        }

        icon = Resources.Load<Sprite>(imagePath);
    }

	public string Name {
		get {
			return name;
		}
	}

	public PowerUpType Type {
		get {
			return type;
		}
	}

    public List<PowerUpEffect> Effects {
        get {
            return effect;
        }
    }

    public List<PowerUpEffect> Penalties {
        get {
            return penalty;
        }
    }

    public Sprite Icon {
        get {
            return icon;
        }
    }
}
