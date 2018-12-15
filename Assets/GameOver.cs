using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private PlayerController player;
    public GameObject DeathUi;

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
        DeathUi.SetActive(true);
    }

    //Se fait appeler quand le joueur 
    public void RestartGame()
    {
        player.RestartGame();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("StartGame");

    }
}
