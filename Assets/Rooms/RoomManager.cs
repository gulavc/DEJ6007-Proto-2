using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    //reference to the current room the player is in
    public Room CurrentRoom { get; private set; }

    //Reference to the player 
    public PlayerController player;

	

    //Load the room passed in parameter, and place the player at the spawn point of the room
    public void LoadRoom(Room r)
    {
        CurrentRoom = r;
        player.transform.position = r.spawnPoint.position;
    }
}
