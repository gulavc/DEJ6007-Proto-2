using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBoomBox : GunClass {

    public GameObject bulletPrefab;
    public GameObject gunPoint;

    bool isFiring = false;
          
    
    //Fires the primary fire of the gun
    public override void FireGun()
    {
        if (isFiring == false)
        {
            isFiring = true;
            StartCoroutine(PistolBulletDelay());
        }
    }

    //Fires the secondary fire of a gun, if any is present
    public override void FireGunSecondary()
    {
        if (isFiring == false)
        {
            isFiring = true;
            StartCoroutine(SecondaryPistolBulletDelay());
        }
    }

    public IEnumerator PistolBulletDelay()
    {
        GameObject bullet;

        for (int i = 0; i < 1; i++) {
            bullet = Instantiate(bulletPrefab, gunPoint.transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(gunPoint.transform.right * 7.5f);

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

    // Secondary fire qui n'est pas tant nécessaire
    public IEnumerator SecondaryPistolBulletDelay()
    {
        GameObject bullet;

        for (int i = 0; i < 3; i++) {
            bullet = Instantiate(bulletPrefab, gunPoint.transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(gunPoint.transform.right * 50f);

            yield return StartCoroutine(SecondaryBulletTimer());
        }
        isFiring = false;
    }

    public IEnumerator SecondaryBulletTimer()
    {
        float timer = 0.2f;
        while(timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
    }
    
}
