using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransitionTrigger : MonoBehaviour {

    private Room parent;
    public Direction doorDirection;

	// Use this for initialization
	void Start () {
        parent = GetComponentInParent<Room>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            parent.Transition(doorDirection);
        }
    }
}
