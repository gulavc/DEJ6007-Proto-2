using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public int HP { get; private set; }
    public int maxHP;

    public HealthBar healthBar;

	// Use this for initialization
	void Start () {
        HP = maxHP;
        healthBar.barDisplay = 1f;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Damage(10);
        }

        Vector3 positionFix = this.transform.position;
        positionFix.y = -positionFix.y;
        Vector2 screenPos = Camera.main.WorldToScreenPoint(positionFix);
        Debug.Log(screenPos);

        healthBar.pos = screenPos + healthBar.posOffset;

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

    //Kills the enemy
    public void Die()
    {
        Destroy(this.gameObject);
    }
}
