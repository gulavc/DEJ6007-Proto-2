using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceWay : MonoBehaviour {

    //Trouve joueur
    //Accede ID
    //ID entrance = Id joueur
    //Si meme ID, amener le joueur a se spot
    //GetComponentInChildren

    public string inPut;

    private string incomingID;

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        incomingID = player.GetComponentInChildren<PlayerTransitionID>().playerIDTransition;
        Compare();
    }

    void Compare()
    {
        if (inPut == incomingID)
        {
            player.gameObject.transform.position = this.gameObject.transform.position;
        }
    }
}
