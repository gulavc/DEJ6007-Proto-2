using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : EnemyBehavior
{
    //The projectile the enemy will shoot
    public BulletEndOfLife bullet;

    //How long between 2 shots
    public float shootingDelay;

    //Private variables to handle shooting
    private bool canShoot;
    private float cooldownTimer;
    

    //General behaviour of the enemy AI
    //Shooting enemy stays still but will try to shoot the player if they are within range
    public override void Execute()
    {
        //If the reference to the player isn't set, find it and set it
        if (Player == null)
        {
            Player = FindObjectOfType<PlayerController>();
        }



        //If the enemy is close enough to the player, shoot him, if possible!
        if (Vector3.Distance(Player.transform.position, Self.transform.position) <= attackRange)
        {

            if (canShoot)
            {
                canShoot = false;

                //Calculate the unit vector in the direction of the player
                Vector3 direction = Vector3.Normalize(Player.transform.position - Self.transform.position);

                float radius = Self.GetComponent<SphereCollider>().radius/4f;

                //Instanciate a bullet
                BulletEndOfLife b = Instantiate(bullet, Self.transform.position + direction * radius, Quaternion.identity);

                //Shoot it
                b.GetComponent<Rigidbody>().velocity = (direction * bullet.bulletForce);

                //Set the timer to start the cooldown between shots
                cooldownTimer = shootingDelay;

            }
        }

        //If the enemy can't shoot, decrement their cooldown timer until they can shoot again. We do this even if the player isn't in range as the enemy can still cool down no matter where the player is
        if (!canShoot)
        {
            cooldownTimer -= Time.deltaTime;
            if(cooldownTimer <= 0)
            {
                canShoot = true;
            }
        }

    }

    public override void HandleCollision(Collision collision)
    {
        //Nothing here, as the shooting enemy doesn't have a specific behavior when collided with
    }

}
