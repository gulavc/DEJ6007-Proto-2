using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDontDestroy : MonoBehaviour {

	// On veut pas que le joueur soit détruit au moment de changer de scène
	void Awake () {
        DontDestroyOnLoad(this.gameObject);
    }
	
}
