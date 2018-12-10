using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehavior : MonoBehaviour
{

    public PlayerController Player { get; set; }
    public Enemy Self { get; set; }
    public float attackRange;
    public float movementSpeed;
    public int damage;

    public abstract void Execute();
    public abstract void HandleCollision(Collision collision);

}
