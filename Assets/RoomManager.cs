using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    private Room currentRoom;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Transition(Direction d)
    {
        //Room nextRoom = currentRoom.GetNextRoom(d);
        //Place player in the opposite position
        //instanciate new room
        //destroy old room
    }

    public void LoadRoom(Room r)
    {

    }
}
