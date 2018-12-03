using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour {

    private void OnColliderEnter(Collider other)
    {
        if (other.gameObject.tag == "BulletStop")
        {
            Destroy(this.gameObject);
        }
    }
}
