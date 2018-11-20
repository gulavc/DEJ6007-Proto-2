using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //References to other scripts
    public PlayerInputManager playerInput;

    //Player options
    public float moveSensitivity;
    public float dashDuration;
    public float dashStrength;

    //private variables for internal use
    private Direction playerFacing = Direction.S;

	// Use this for initialization
	void Start () {

	}
	
	
	void FixedUpdate () {
        HandleMovement();
        playerFacing = CalculateDirection();
        HandleDash();

        HandleFire();
		
	}
    

    private void HandleMovement()
    {
        transform.Translate(playerInput.Horizontal * moveSensitivity, playerInput.Vertical * moveSensitivity, 0f);
    }

    private Direction CalculateDirection()
    {

        return Direction.S;
    }

    private void HandleDash()
    {
        if (playerInput.Dash)
        {
            StartCoroutine(Dash(playerFacing));
        }
            
    }

    private void HandleFire()
    {
        //activeWeapon.FireMain();
        //activeWeapon.FireAlt();
    }

    private IEnumerator Dash(Direction dir)
    {
        for(float time = dashDuration; time >= 0f;)
        {
            transform.Translate(Vector3.down * dashStrength);
            time -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        

    }

}
