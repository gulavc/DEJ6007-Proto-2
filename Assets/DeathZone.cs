using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour {

    private PlayerController player;

    private bool deathZoneHit = false;

    //public parameters
    //damage taken when the player hits the deathzone
    public int damage = 10;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        transform.position = player.transform.position + new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y, 0);
        if (deathZoneHit)
        {
            player.RespawnPlayer(damage);
            deathZoneHit = false;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            deathZoneHit = true;
        }
    }
    
}
