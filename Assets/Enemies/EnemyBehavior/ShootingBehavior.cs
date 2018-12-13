using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : EnemyBehavior
{

    public Transform patrolPoint;
    private Transform spawnPoint;
    private int moveStep = 0;
    Vector3 targetPosition;

    //public Bullet bullet 

    //General behaviour of the enemy AI
    //Shooting enemy will try to shoot the player, while patrolling between its spawn point and another fixed point
    public override void Execute()
    {
        if (Player == null)
        {
            Player = FindObjectOfType<PlayerController>();
        }

        if (spawnPoint == null)
        {
            spawnPoint = Self.transform;
        }


        //If the enemy is close enough to the player, shoot him!
        if (Vector3.Distance(Player.transform.position, Self.transform.position) <= attackRange)
        {
            //SHOOT BITCH!
            Debug.Log("pewpewpew");
        }

        //If first time, initialize destination
        if (targetPosition == Vector3.zero)
        {
            targetPosition = patrolPoint.position;
        }

        //Move along the path towards next waypoint
        Self.transform.position = Vector3.ProjectOnPlane(Vector3.MoveTowards(Self.transform.position, targetPosition, movementSpeed), Vector3.back);

        //If point is reached, change target to next waypoint
        if (Self.transform.position == targetPosition)
        {
            moveStep = (moveStep + 1) % 2;
            switch (moveStep)
            {
                case 0:
                    targetPosition = patrolPoint.position;
                    break;
                case 1:
                    targetPosition = spawnPoint.position;
                    break;
                default:
                    targetPosition = patrolPoint.position;
                    break;
            }
        }

    }

    public override void HandleCollision(Collision collision)
    {
        //Knockback enemy????
    }
}
