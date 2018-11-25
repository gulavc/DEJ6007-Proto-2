using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {

    public Room up, down, left, right;

    private RoomManager rm;

	// Use this for initialization
	void Start () {
        rm = GameObject.FindObjectOfType<RoomManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

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

    //Returns the adjacent room, depending on the specified direction
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
