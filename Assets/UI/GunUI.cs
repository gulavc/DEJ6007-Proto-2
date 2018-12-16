using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUI : MonoBehaviour {

    public GameObject gun1text;
    public GameObject gun2text;
    public GameObject gun3text;
    public PlayerController player;

    private int currentGun = int.MinValue;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(player.CurrentGunID == 0 && currentGun != 0)
        {
            currentGun = 0;
            Gun1();
        }

        if (player.CurrentGunID == 1 && currentGun != 1)
        {
            currentGun = 1;
            Gun2();
        }

        if (player.CurrentGunID == 2 && currentGun != 2)
        {
            currentGun = 2;
            Gun3();
        }

    }

    void Gun1()
    {
        gun1text.GetComponent<Text>().color = Color.yellow;
        gun2text.GetComponent<Text>().color = Color.black;
        gun3text.GetComponent<Text>().color = Color.black;


    }

    void Gun2()
    {
        gun1text.GetComponent<Text>().color = Color.black;
        gun2text.GetComponent<Text>().color = Color.yellow;
        gun3text.GetComponent<Text>().color = Color.black;

    }

    void Gun3()
    {
        gun1text.GetComponent<Text>().color = Color.black;
        gun2text.GetComponent<Text>().color = Color.black;
        gun3text.GetComponent<Text>().color = Color.yellow;

    }


}
