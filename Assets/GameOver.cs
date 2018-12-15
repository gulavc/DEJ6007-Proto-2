using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //Affiche le UI de gameOver
    public void LoseGame()
    {
        
    }

    //Se fait appeler quand le joueur 
    public void RestartGame()
    {
        player.RestartGame();
    }
}
