using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public PlayerController player;

    public Text HPText; 
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Updates the value of the player's HP
	void Update () {
        HPText.text = "HP: " + player.CurrentHP + " / " + player.MaxHP;
	}
}
