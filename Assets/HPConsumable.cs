using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPConsumable : Consumable {

    public int healthGain;

    public override void PickupConsumable(PlayerController player)
    {
        player.AddHP(healthGain);
    }
}
