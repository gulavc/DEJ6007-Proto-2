using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Startup : MonoBehaviour {
    public GameObject ControlsUI;

    public void StartGame()
    { 
       
        SceneManager.LoadScene("iLevelDesign");
        Debug.Log("Ca part en salade");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartGame");
        Debug.Log("Main Menu");
    }

    public void ControlsScreen()
    {
        ControlsUI.SetActive(true);
    }

    public void ControlsReturn()
    {
        ControlsUI.SetActive(false);
    }

}
