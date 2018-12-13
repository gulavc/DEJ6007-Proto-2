using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEndOfLife : MonoBehaviour {

    private void OnColliderEnter(Collider other)
    {
        if (other.gameObject.tag == "BulletStop")
        {
            Destroy(this.gameObject);
        }
            }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().RemoveHP(10);
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(10);
            Destroy(this.gameObject);
        }
    }
}
