using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : MonoBehaviour {

    PlayerController pl;

	// Use this for initialization
	void Start () {
        //Find a reference to the player
        pl = FindObjectOfType<PlayerController>();
	}

    private void OnTriggerEnter(Collider other)
    {
        //If a player hit the consumable, trigger their effect, whatever it may be, then destroy the consumable
        if(other.tag == "Player")
        {
            PickupConsumable(pl);
            Destroy(this.gameObject);
        }
    }

    //Every consumable needs to implements this
    public abstract void PickupConsumable(PlayerController player);
}
