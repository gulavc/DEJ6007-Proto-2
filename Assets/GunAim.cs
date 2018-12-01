using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GunAim {    

    // Rotates a gameObject around another one to aim at the mouse
    public static void Rotate (GameObject gun, GameObject gunParent) {

        Vector3 current, goal, mousePosition, test;

        current = gun.transform.position - gunParent.transform.position;
        current.z = 0;

        //Input the mouse position in pixel space. Artificially set the depth at 10 pixels away from the x-y plane to make sure the next function doesn't return nonsense
        test = Input.mousePosition;
        test.z = 10;

        //Transform the mouse position into 3D coordinates, then set the depth to 0 because we only care about the position on the x-y plane
        mousePosition = Camera.main.ScreenToWorldPoint(test);
        mousePosition.z = 0;

        //Calculate the target orientation vector
        goal = mousePosition - gunParent.transform.position;
        goal.z = 0;

        //Calculate the angle between the current direction and the position of the mouse, then use a cross product to determine the polarity of the rotation
        float angle = Vector3.Angle(current, goal);
        Vector3 cross = Vector3.Cross(current, goal);
        if (cross.z > 0)
        {
            angle = -angle;
        }
        
        //Rotate the object to align with the goal vector
        gun.transform.RotateAround(gunParent.transform.position, Vector3.back, angle);

        
        

	}
}
