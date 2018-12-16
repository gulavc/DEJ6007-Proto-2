using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This consumable heals the player
public class HPConsumable : Consumable {

    //How much health to regain when picked up
    public int healthGain;

    public override void PickupConsumable(PlayerController player)
    {
        player.AddHP(healthGain);
    }
}
