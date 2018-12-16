using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //References to other scripts
    public PlayerInputManager playerInput;

    //private references to other components
    private RoomManager rm;
    private Rigidbody rb;

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

    //List of Guns available to the player
    public GunClass[] availableGuns;
    private bool[] unlockedGuns;
    private int currentGunID;

    //public Parameters
    public int CurrentHP { get; private set; }



    // Use this for initialization
    void Start()
    {
        if(rm == null)
        {
            rm = GameObject.FindObjectOfType<RoomManager>();
        }
        if(rb == null)
        {
            rb = this.gameObject.GetComponent<Rigidbody>();
        }

        playerFacing = Direction.S;
        playerDirection = Direction.S.UnitVector();
        isDashing = false;

        CurrentHP = MaxHP;
        currentGun = null;

        //Lock all guns at the beginning of the game
        unlockedGuns = new bool[availableGuns.Length];
        currentGunID = int.MinValue;

        for (int i = 0; i < availableGuns.Length; ++i)
        {
            unlockedGuns[i] = false;
            availableGuns[i].gameObject.SetActive(false);
        }

        //Set timescale to 1, as it will be 0 if the player has previously died or completed a game
        Time.timeScale = 1;

    }


    void FixedUpdate()
    {
        playerFacing = CalculateDirection();

        HandleMovement();

        HandleDash();

        HandleFire();

        HandleSwitchGun();

    }


    private void HandleMovement()
    {
        transform.Translate(playerInput.Horizontal * moveSensitivity, playerInput.Vertical * moveSensitivity, 0f);
    }

    private Direction CalculateDirection()
    {
        //Calculate the angle between the direction of the input & the direction the sprite is facing. If > 45 degrees, ajust the facing direction to the nearest 45° of the input direction
        playerDirection = new Vector3(playerInput.Horizontal, playerInput.Vertical, 0f).normalized;
        if (Vector3.Angle(playerDirection, playerFacing.UnitVector()) >= 22.5f)
        {
            for (Direction d = Direction.N; d <= Direction.NW; d++)
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
        if (playerInput.Dash && !isDashing)
        {

            StartCoroutine(Dash(playerFacing));
        }

    }

    private void HandleFire()
    {
        if (currentGun != null)
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


    }


    //Dashes in the specified direction for dashDuration, with dashStrength
    private IEnumerator Dash(Direction dir)
    {
        rb.useGravity = false;
        isDashing = true;
        for (float time = dashDuration; time >= 0f;)
        {
            transform.Translate(dir.UnitVector() * dashStrength);
            time -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        playerInput.Dash = false;
        isDashing = false;
        rb.useGravity = true;

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



    public void UnlockGun(int ID)
    {
        if (ID < unlockedGuns.Length)
        {
            unlockedGuns[ID] = true;
            if (currentGun == null)
            {
                currentGun = availableGuns[ID];
                currentGun.gameObject.SetActive(true);
                currentGunID = ID;
            }
        }

    }

    private void HandleSwitchGun()
    {
        if (playerInput.NextGun)
        {
            playerInput.NextGun = false;

            //Verifty that the gunID is valid, which means at least 1 gun has been unlocked
            if (currentGunID >= 0)
            {
                Debug.Log("Switching Guns");
                int nextID = (currentGunID + 1) % unlockedGuns.Length;
                //Check if the nextt gun on the list is unlocked, looping back if at the end of the list
                if (unlockedGuns[nextID])
                {
                    SwitchGun(nextID);

                }
                else
                {
                    //If the next gun is false (hasn't been unlocked yet) go back to the start of the list.
                    nextID = 0;
                    SwitchGun(nextID);
                }
                Debug.Log("ID: " + currentGunID);
            }



        }
    }

    private void SwitchGun(int ID)
    {
        if (unlockedGuns[ID] == true)
        {
            currentGun.gameObject.SetActive(false);

            currentGun = availableGuns[ID];
            currentGunID = ID;
            currentGun.gameObject.SetActive(true);
        }
    }

    //Respawns the player at the start of the current room, dealing damage in the process (0 by default)
    public void RespawnPlayer(int damage = 0)
    {
        RemoveHP(damage);
        this.transform.position = rm.CurrentRoom.spawnPoint.position;
    }


    public void RestartGame()
    {
        //TODO: Restart game;
        Debug.Log("GameRestarted");
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
        GameObject.FindObjectOfType<GameOver>().LoseGame();
    }

}
