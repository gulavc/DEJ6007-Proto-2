using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    
    //reference to the UI to turn it on/off
    public GameObject DeathUi;
    

    //Affiche le UI de gameOver
    public void LoseGame()
    {
        DeathUi.SetActive(true);
        //set timescale to 0 to prevent player movement
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
