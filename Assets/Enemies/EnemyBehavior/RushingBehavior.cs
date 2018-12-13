using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushingBehavior : EnemyBehavior
{

    

    //General behaviour of the enemy AI
    //Rushing enemy will try to rush the player, despawning and dealing damage if they hit
    public override void Execute()
    {
        if (Player == null)
        {
            Player = FindObjectOfType<PlayerController>();
        }


        //If the enemy is close enough to the player, rush his position
        if (Vector3.Distance(Player.transform.position, Self.transform.position) <= attackRange)
        {
            Self.transform.position = Vector3.ProjectOnPlane(Vector3.MoveTowards(Self.transform.position, Player.transform.position, movementSpeed), Vector3.back);
        }
    }

    //Handles the collisions from the enemy object
    public override void HandleCollision(Collision collision)
    {        
        if (collision.collider.gameObject.tag == "Player")
        {
            Player.RemoveHP(damage);
            Destroy(Self.gameObject);
            
        }
    }
}
    
