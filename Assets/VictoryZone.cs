using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryZone : MonoBehaviour {

    private bool victory = false;

    

    // Update is called once per frame
    void Update()
    {
        if (victory)
        {
            //TODO: Appeler la fonction du vicotry UI qui affiche la victoire


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
