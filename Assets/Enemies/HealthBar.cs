using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//This script takes care of updating the "health bar" (more like health text) of the enemies
public class HealthBar : MonoBehaviour
{

    //reference to the text component
    private Text hpText;

    void Start()
    {
        //Find the text component in the child
        hpText = this.gameObject.GetComponentInChildren<Text>();
    }

    //Called by the enemy script to update the text of the health bar
    public void updateText(int currentHP)
    {
        hpText.text = currentHP + " HP";
    }

}