using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUnlockConsumable : Consumable {

    //ID of the gun to unlock
    public int gunID;

    public override void PickupConsumable(PlayerController player)
    {
        player.UnlockGun(gunID);
    }
    
}
