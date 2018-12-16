using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryZone : MonoBehaviour {

    private bool victory = false;
    public GameObject VictoryUI;

    

    // Update is called once per frame
    void Update()
    {
        if (victory)
        {
            Time.timeScale = 0;
            VictoryUI.SetActive(true);
            victory = false;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            victory = true;
        }
    }
}
