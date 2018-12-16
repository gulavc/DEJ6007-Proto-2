using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This consumable unlocks a gun for the player, referenced by its ID
public class GunUnlockConsumable : Consumable {

    //ID of the gun to unlock
    public int gunID;

    //When picked up, unlocks the gun with the appropriate ID
    public override void PickupConsumable(PlayerController player)
    {
        player.UnlockGun(gunID);
    }
    
}
