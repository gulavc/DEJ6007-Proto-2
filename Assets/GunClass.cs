using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunClass : MonoBehaviour {

    public int GunID { get; set; }

    public string GunName { get; set; }

    public int MaxAmmunition { get; set; }
    public int CurrentAmmunition { get; set; }
    public int TotalAmmunition { get; set; }

    public int MaxBulletHolder { get; set; }
    public int CurrentBulletHolder { get; set; }
    public float BulletSpeed { get; set; }

    public float ReloadTime { get; set; }

    public float GunDamage { get; set; }
    public float SecondaryDamage { get; set; }
    public float GunFireRate { get; set; }
    
    public float KnockbackForce { get; set; }
    public float RecoilForce { get; set; }

    public GunClass()
    {

        this.GunID = 0;
        this.GunName = "";
        this.MaxAmmunition = 0;
        this.CurrentAmmunition = 0;
        this.TotalAmmunition = 0;
        this.MaxBulletHolder = 0;
        this.CurrentBulletHolder = 0;
        this.BulletSpeed = 0;
        this.ReloadTime = 0;
        this.GunDamage = 0;
        this.SecondaryDamage = 0;
        this.GunFireRate = 0;
        
        this.KnockbackForce = 0;
        this.RecoilForce = 0;
    }

    public GunClass(int gunID, string gunName, int maxAmmunition, int currentAmmunition, int totalAmmunition,
        int maxBulletHolder, int currentBulletHolder, float bulletSpeed, float reloadTime, float gunDamage, float secondaryDamage,
        float gunFireRate, float gunWeight, float knockbackForce, float recoilForce)
    {

        this.GunID = gunID;
        this.GunName = gunName;
        this.MaxAmmunition = maxAmmunition;
        this.CurrentAmmunition = currentAmmunition;
        this.TotalAmmunition = totalAmmunition;
        this.MaxBulletHolder = maxBulletHolder;
        this.CurrentBulletHolder = currentBulletHolder;
        this.BulletSpeed = bulletSpeed;
        this.ReloadTime = reloadTime;
        this.GunDamage = gunDamage;
        this.SecondaryDamage = secondaryDamage;
        this.GunFireRate = gunFireRate;
       
        this.KnockbackForce = knockbackForce;
        this.RecoilForce = recoilForce;
    }


    public void Update()
    {
        //If a gun has a parent (probably a player), aim the gun in direction of the mouse
        if(this.transform.parent != null)
        {
            GunAim.Rotate(this.gameObject, this.transform.parent.gameObject);
        }
    }


}
