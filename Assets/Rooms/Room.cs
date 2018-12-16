﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    //Adjacent rooms. Leave null if no adjacent room
    public Room up, down, left, right;

    //Transform indicating the position of where to spawn the player once they enter the room
    public Transform spawnPoint;


    //reference to the room manager
    private RoomManager rm;

	// Use this for initialization
	void Start () {
        rm = GameObject.FindObjectOfType<RoomManager>();
	}
	
    //transitions the player to the room in direction D
    public void Transition(Direction d)
    {
        //Find the next room to load depending on the direction specified
        Room r = GetNextRoom(d);

        //If the room is valid (i.e. not null), call on the RoomManager to load the next room
        if(r != null)
        {
            rm.LoadRoom(r);
        }
        
    }

    //Returns the adjacent room, depending on the specified direction. If invalid direction, return null, i.e. no room
    public Room GetNextRoom(Direction d)
    {
        switch (d)
        {
            case Direction.N:
                return up;
            case Direction.E:
                return right;
            case Direction.S:
                return down;
            case Direction.W:
                return left;
            default:
                return null;
        }
    }
    
}
