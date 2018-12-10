using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    private Room currentRoom;
    private Camera cam;

    //Parametres modifiables dans l'éditeur
    public Vector3 cameraOffset;
    public PlayerController player;

	// Use this for initialization
	void Start () {
        //cam = GetComponentInChildren<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Load the room passed in parameter, and place the player at the [incoming] direction door
    public void LoadRoom(Room r, Direction incoming)
    {
        currentRoom = r;
        //cam.transform.position = (r.transform.position + cameraOffset);
        Vector3 playerOffset;
        switch (incoming)
        {
            case Direction.N:
                playerOffset = new Vector3(0, -currentRoom.playableHeight / 2);
                break;
            case Direction.E:
                playerOffset = new Vector3(-currentRoom.playableWitdth / 2, 0);
                break;
            case Direction.S:
                playerOffset = new Vector3(0, currentRoom.playableHeight / 2);
                break;
            case Direction.W:
                playerOffset = new Vector3(currentRoom.playableWitdth / 2, 0);
                break;
            default:
                playerOffset = new Vector3();
                break;
        }
        player.transform.position = currentRoom.transform.position + playerOffset;
    }
}
