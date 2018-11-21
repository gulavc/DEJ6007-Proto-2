using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //Hello world
    //References to other scripts
    public PlayerInputManager playerInput;

    //private references to other components
    private Rigidbody rb;

    //Player options
    public float moveSensitivity;
    public float dashDuration;
    public float dashStrength;
    public float maxSpeed;

    //private variables for internal use
    private Vector3 playerDirection;
    private Direction playerFacing;
    private bool isDashing;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        playerFacing = Direction.S;
        playerDirection = Direction.S.UnitVector();
        isDashing = false;
    }
	
	
	void FixedUpdate () {
        playerFacing = CalculateDirection();

        HandleMovement();
        
        HandleDash();

        HandleFire();
		
	}
    

    private void HandleMovement()
    {
        transform.Translate(playerInput.Horizontal * moveSensitivity, playerInput.Vertical * moveSensitivity, 0f);
        /*rb.AddForce(playerDirection * moveSensitivity);

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.AddForce(-playerDirection * Mathf.Pow(rb.velocity.magnitude - maxSpeed, 2));
        }*/
    }

    private Direction CalculateDirection()
    {
        //Calculate the angle between the direction of the input & the direction the sprite is facing. If > 45 degrees, ajust the facing direction to the nearest 45° of the input direction
        playerDirection = new Vector3(playerInput.Horizontal, playerInput.Vertical, 0f).normalized;
        if (Vector3.Angle(playerDirection, playerFacing.UnitVector()) >= 22.5f)
        {
            for(Direction d = Direction.N; d <= Direction.NW; d++)
            {
                if (Vector3.Angle(playerDirection, d.UnitVector()) < 45)
                {
                    return d;
                }
            }
        }

        //If the current angle is < 45°, the facing direction doesn't need to change
        return playerFacing;
    }

    private void HandleDash()
    {
        if (playerInput.Dash && !isDashing)        {
            
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
        isDashing = true;
        for(float time = dashDuration; time >= 0f;)
        {
            transform.Translate(dir.UnitVector() * dashStrength);
            time -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        playerInput.Dash = false;
        isDashing = false;

    }

}
