using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : GunClass {

    public GameObject bulletPrefab;
    public GameObject gunPoint;

    bool isFiring = false;


    public override void FireGun()
    {
        if (isFiring == false)
        {
            isFiring = true;
            StartCoroutine(PistolBulletDelay());
        }
    }

    public override void FireGunSecondary()
    {
        //No secondary fire, so default back to primary
        FireGun();
    }

    public IEnumerator PistolBulletDelay()
    {
        GameObject bullet;

        for (int i = 0; i < 1; i++) {
            bullet = Instantiate(bulletPrefab, gunPoint.transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = Vector3.ProjectOnPlane(Vector3.Normalize(GunAim.orientation), Vector3.back) * 10; 

            yield return StartCoroutine(BulletTimer());
        }
        isFiring = false;
    }

    public IEnumerator BulletTimer()
    {
        float timer = 0.05f;
        while(timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
    }
    

    
}
