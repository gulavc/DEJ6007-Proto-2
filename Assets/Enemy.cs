using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public int HP { get; private set; }
    public int maxHP;

    public HealthBar healthBar;

    public EnemyBehavior enemyAI;

	// Use this for initialization
	void Start () {
        HP = maxHP;
        healthBar.barDisplay = 1f;

        enemyAI.Self = this;

    }

    private void Update()
    {
        //Temporary hack to damage the enemies
        if (Input.GetKeyDown(KeyCode.H))
        {
            Damage(10);
        }
               

        //Execute the AI
        enemyAI.Execute();

        //Update the position of the Health Bar
        UpdateHealthBarPosition();

    }

    //Deals damage to the enemy
    public void Damage(int damage)
    {
        HP -= damage;
        healthBar.barDisplay = (float)HP / maxHP;

        if(HP <= 0)
        {
            Die();
        }
    }

    //Moves the health bar to stay above the enemy
    public void UpdateHealthBarPosition()
    {
        Vector3 positionFix = this.transform.position;
        positionFix.y = -positionFix.y;
        Vector2 screenPos = Camera.main.WorldToScreenPoint(positionFix);

        healthBar.pos = screenPos + healthBar.posOffset;
    }

    //Kills the enemy
    public void Die()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        enemyAI.HandleCollision(collision);
    }
}
