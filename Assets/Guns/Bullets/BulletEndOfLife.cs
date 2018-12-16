using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEndOfLife : MonoBehaviour {

    //The type of target that will be dealt damage by this bullet
    public DamageType damageType;
    //How much damage this bullet does
    public int damage = 10;
    //How hard do you shoot it?
    public float bulletForce = 50;
    //How long does it live if it doesn't hit anything?
    public float bulletLifetime = 5;

    void Start()
    {
        //After initialization, destroy the bullet at the end of its lifetime
        Destroy(this.gameObject, bulletLifetime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && (damageType == DamageType.Player || damageType == DamageType.All))
        {
            collision.gameObject.GetComponent<PlayerController>().RemoveHP(damage);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy" && (damageType == DamageType.Enemy || damageType == DamageType.All))
        {
            collision.gameObject.GetComponent<Enemy>().Damage(damage);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "BulletStop")
        {
            Destroy(this.gameObject);
        }
    }
}


//Enum to determine who can get hit by which bullet
public enum DamageType
{
    Player,
    Enemy,
    All
}
