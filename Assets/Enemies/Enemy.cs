using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    //Current and Max HP of the enemy
    public int HP { get; private set; }
    public int maxHP;

    //Reference to the healthBar
    public HealthBar healthBar;

    //The base AI dictating the behavior of the enemy
    public EnemyBehavior enemyAI;
    //Copy of the base AI for this individual enemy
    private EnemyBehavior selfAI;

	// Use this for initialization
	void Start () {
        HP = maxHP;
        healthBar.updateText(maxHP);

        //Create a copy of the AI and set Self as a reference to itself on the AI script
        selfAI = Instantiate(enemyAI);
        selfAI.Self = this;

    }

    private void Update()
    {
        //Test Cheat Code. Decided to leave it in to make testing easier. 
        //Hitting "H" while in play will damage all ennemies by 10 points
        if (Input.GetKeyDown(KeyCode.H))
        {
            Damage(10);
        }


        //Execute the AI behaviour linked to this enemy
        selfAI.Execute();

    }

    //Deals damage to the enemy
    public void Damage(int damage)
    {
        HP -= damage;
        healthBar.updateText(HP);

        if(HP <= 0)
        {
            Die();
        }
    }
    

    //Kills the enemy
    public void Die()
    {
        Destroy(this.gameObject);
    }

    //If an enemy needs to react to collisions with players, or anything else, we let their AI handle it
    private void OnCollisionEnter(Collision collision)
    {
        selfAI.HandleCollision(collision);
    }
}
