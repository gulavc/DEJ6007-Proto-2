using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Trigger to detect when a player should transition into the next room
public class RoomTransitionTrigger : MonoBehaviour {

    //Reference to the room this trigger is a part of
    private Room parent;

    //Direction this door should transition you towards
    public Direction doorDirection;

	// Use this for initialization
	void Start () {
        parent = GetComponentInParent<Room>();
	}	


    private void OnTriggerEnter(Collider other)
    {
        //If a collision with a player is detected, call on the parent room to initialize a transition in the direction of the door
        if(other.tag == "Player")
        {
            parent.Transition(doorDirection);
        }
    }
}
