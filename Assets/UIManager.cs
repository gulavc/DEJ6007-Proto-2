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
	
	// Update is called once per frame
	void Update () {
        HPText.text = "HP: " + player.CurrentHP + " / " + player.MaxHP;
	}
}
