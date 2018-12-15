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
        if (isFiring == false)
        {
            isFiring = true;
            StartCoroutine(SecondaryPistolBulletDelay());
        }
    }


    new void Update () {
        base.Update();

        if (isFiring == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isFiring = true;
                StartCoroutine(PistolBulletDelay());    
            }
            else if (Input.GetMouseButtonDown(1))
            {
                isFiring = true;
                StartCoroutine(SecondaryPistolBulletDelay());
            }
        }
        
	}

    public IEnumerator PistolBulletDelay()
    {
        GameObject bullet;

        for (int i = 0; i < 10; i++) {
            bullet = Instantiate(bulletPrefab, gunPoint.transform.position, transform.rotation) as GameObject;
            bullet.GetComponent<Rigidbody>().velocity = Vector3.ProjectOnPlane(Vector3.Normalize(GunAim.orientation), Vector3.back) * 50; //transform.up * 50f;

            Debug.Log(GunAim.orientation);

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
