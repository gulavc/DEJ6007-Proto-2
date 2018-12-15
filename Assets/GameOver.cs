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


    //Affiche le UI de gameOver
    public void LoseGame()
    {
        DeathUi.SetActive(true);
        Time.timeScale = 0;
    }

    //Se fait appeler quand le joueur 
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("StartGame");

    }
}
