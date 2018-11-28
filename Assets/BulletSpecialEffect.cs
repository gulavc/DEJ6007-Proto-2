using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpecialEffect : MonoBehaviour
{
    private float timer;

    private float radius = 5f;
    private float power = 10f;

    public IEnumerator Start()

    {
        float timer = 100f;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
    }

    public void Update()
    {
        if (timer == 0f)
        {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 3.0f);
            }
        }
    }
}




