using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Base class of the AI, contains variables and abstract methods to be implemented by all AIs
public abstract class EnemyBehavior : MonoBehaviour
{

    //Reference to the player
    public PlayerController Player { get; set; }
    //Reference to the enemy itself
    public Enemy Self { get; set; }
    //Detection/Aggro range
    public float attackRange;
    //How fast the enemy moves, if applicable
    public float movementSpeed;
    //How much damage the enemy deals per attack
    public int damage;

    //Main AI function, called every update by the enemy script to determine how it acts
    public abstract void Execute();
    //If the enemy collides with something, we let the AI handle it
    public abstract void HandleCollision(Collision collision);

}
