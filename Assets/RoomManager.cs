using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    //private Room currentRoom;
    //private Camera cam;

    //Parametres modifiables dans l'éditeur
    //public Vector3 cameraOffset;
    public PlayerController player;

	// Use this for initialization
	void Start () {
        //cam = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Load the room passed in parameter, and place the player at the [incoming] direction door
    public void LoadRoom(Room r)
    {
        //currentRoom = r;
        //cam.transform.position = (r.transform.position + cameraOffset);
        player.transform.position = r.spawnPoint.position;
    }
}
