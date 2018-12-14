﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpecialEffect : MonoBehaviour
{

    //How long until the bullet explodes, if it doesn't hit anything
    public float timer = 7f;

    //The prefab of the secondary bullet generated in the explosion
    public BulletEndOfLife bullet;

    //How many secondary bullets are generated
    public float numBullets = 4f;

    //How fast secondary bullets go
    private float speedBullets = 3f;

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



    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == "Enemy" || tag == "BulletStop")
        {
            Boom();
            Destroy(this.gameObject);
        }
        
    }

    public void Boom()
    {
        //Angle between every bullet
        float angle = 360f / numBullets;

        for (int i = 0; i < numBullets; ++i)
        {

            //Spawns the bullet and rotates it to initiate a spread
            BulletEndOfLife b = Instantiate(bullet, this.transform.position, Quaternion.identity * Quaternion.AngleAxis(angle * i, Vector3.back));
                      

            //Translate the bullet just a tad so they don't all spawn on each other
            b.transform.Translate(b.transform.forward * 0.5f);

            b.GetComponent<Rigidbody>().velocity = b.transform.right * speedBullets;
        }


    }

}



/**Vector3 explosionPos = this.gameObject.transform.position;
Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
foreach (Collider hit in colliders)
{
    Rigidbody rb = hit.GetComponent<Rigidbody>();
    if (rb != null){
        rb.AddExplosionForce(power, explosionPos, radius, 3.0f); }
}*/


