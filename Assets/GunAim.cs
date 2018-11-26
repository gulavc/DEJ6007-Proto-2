using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour {

    private Vector3 current;
    private Vector3 goal;
    private Vector3 mousePosition;

    // Update is called once per frame
    void Update () {
        current = transform.position - transform.parent.position;
        current.z = 0;

        Vector3 test = Input.mousePosition;
        test.z = 10;

        mousePosition = Camera.main.ScreenToWorldPoint(test);
        mousePosition.z = 0;

        goal = mousePosition - transform.parent.position;
        goal.z = 0;

        transform.RotateAround(transform.parent.position, Vector3.back, Vector3.Angle(current, goal));
        

	}
}
