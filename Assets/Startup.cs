using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Startup : MonoBehaviour {
    public GameObject ControlsUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    { 
       
        SceneManager.LoadScene("iLevelDesign");
        Debug.Log("Ca part en salade");
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
