using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //References to other scripts
    public PlayerInputManager playerInput;

    //private references to other components

    //Player options
    public float moveSensitivity;
    public float dashDuration;
    public float dashStrength;
    public float maxSpeed;

    public int MaxHP;

    //private variables for internal use
    private Vector3 playerDirection;
    private Direction playerFacing;
    private bool isDashing;
    private GunClass currentGun;
    private List<GunClass> availableGuns;

    //public Parameters
    public int CurrentHP { get; private set; }

	// Use this for initialization
	void Start () {

        playerFacing = Direction.S;
        playerDirection = Direction.S.UnitVector();
        isDashing = false;

        CurrentHP = 50;

        //TEMP DO NOT LEAVE THIS
        currentGun = FindObjectOfType<GunBoomBox>();
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
        if (playerInput.MainFire)
        {
            currentGun.FireGun();
        }

        if (playerInput.AltFire)
        {
            currentGun.FireGunSecondary();
        }
       
    }


    //Dashes in the specified direction for dashDuration, with dashStrength
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


    //public functions accessed by other scripts
    public void AddHP(int amount)
    {
        CurrentHP = Mathf.Min(CurrentHP + amount, MaxHP);
    }

    public void RemoveHP(int amount)
    {
        CurrentHP -= amount;
        if (CurrentHP <= 0)
        {
            GameOver();
        }
    }


    private void SelectGun(int gunNumber)
    {
        currentGun = availableGuns[gunNumber];
    }


    private void GameOver()
    {
        Debug.Log("GameOver");
        //GameOver
        //Stop game
        //Show GameOver UI
    }

}
