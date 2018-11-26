using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : MonoBehaviour {

    PlayerController pl;

	// Use this for initialization
	void Start () {
        pl = FindObjectOfType<PlayerController>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PickupConsumable(pl);
            Destroy(this.gameObject);
        }
    }

    public abstract void PickupConsumable(PlayerController player);
}
