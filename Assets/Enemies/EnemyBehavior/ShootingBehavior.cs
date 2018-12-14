using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : EnemyBehavior
{
    //The projectile the enemy will shoot
    public BulletEndOfLife bullet;

    //How long between 2 shots
    public float shootingDelay;


    private bool canShoot;
    private float cooldownTimer;
    

    //General behaviour of the enemy AI
    //Shooting enemy stays still but will try to shoot the player if they are within range
    public override void Execute()
    {
        if (Player == null)
        {
            Player = FindObjectOfType<PlayerController>();
        }



        //If the enemy is close enough to the player, shoot him!
        if (Vector3.Distance(Player.transform.position, Self.transform.position) <= attackRange)
        {

            if (canShoot)
            {
                canShoot = false;

                //Calculate the unit vector in the direction of the player
                Vector3 direction = Vector3.Normalize(Player.transform.position - Self.transform.position);

                //Instanciate a bullet
                BulletEndOfLife b = Instantiate(bullet, Self.transform.position, Quaternion.identity);

                //Shoot it
                b.GetComponent<Rigidbody>().AddForce(direction * bullet.bulletForce);

                //Set the timer to start the cooldown between shots
                cooldownTimer = shootingDelay;

            }
        }

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
        //Knockback enemy????
    }


    private IEnumerator ShootDelay()
    {
        float timer = shootingDelay;
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
        canShoot = true;
    }
}
