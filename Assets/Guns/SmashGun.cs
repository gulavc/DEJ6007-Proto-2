using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashGun : GunClass
{

    public GameObject bulletPrefab;
    public GameObject gunPoint;

    public int numBullets;

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
        //Not implemented as secondary fire turned out to be too ambitious of a feature, so defaults back to primary fire
        FireGun();
    }

    public IEnumerator PistolBulletDelay()
    {
        GameObject bullet;

        for (int i = 0; i < numBullets; i++)
        {
            bullet = Instantiate(bulletPrefab, gunPoint.transform.position, Quaternion.AngleAxis(Random.Range(0,360), Vector3.back)) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.right * 15;

            yield return StartCoroutine(BulletTimer());
        }
        isFiring = false;
    }

    public IEnumerator BulletTimer()
    {
        float timer = 0.01f;
        while (timer > 0f)
        {
            timer -= Time.deltaTime;
            yield return null;
        }
    }
}
