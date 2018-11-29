using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpecialEffect : MonoBehaviour
{
    public float timer = 7f;

    private float radius = 50f;
    private float power = 500f;

    public void Update()

    {


        if (timer > 0f)
        { timer -= Time.deltaTime; }
            
        

        if (timer <= 0f)
        {
            Boom();
            Destroy(this.gameObject);
        }
    }

    public void Boom()
    {
        Vector3 explosionPos = this.gameObject.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null){
                rb.AddExplosionForce(power, explosionPos, radius, 3.0f); }
        }
    }
}




