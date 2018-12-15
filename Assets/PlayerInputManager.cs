using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script manages the inputs for the player and sends them to the controller script
public class PlayerInputManager : MonoBehaviour {

    public float Vertical { get; set; }
    public float Horizontal { get; set; }
    public bool Dash { get; set; }

    public bool MainFire { get; set; }
    public bool AltFire { get; set; }

    public bool NextGun { get; set; }
    public bool PrevGun { get; set; }

    // Use this for initialization
    void Start () {
        Vertical = 0f;
        Horizontal = 0f;
        Dash = false;
        MainFire = false;
        AltFire = false;
    }
	
	// Update is called once per frame
	void Update () {

        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Dash"))
        {
            Dash = true;
        }
        MainFire = Input.GetButtonDown("Fire1");
        AltFire = Input.GetButtonDown("Fire2");

        

    }
}
