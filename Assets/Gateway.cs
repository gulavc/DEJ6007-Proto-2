using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gateway : MonoBehaviour {

    public GameObject ravePlane;

    public string outPut;

    public string inPut;

        

    void OnTriggerEnter(Collider collider)

    {

        if (collider.tag == "Player")
        {
            //On assigne le ID de la sortie au joueur
            collider.gameObject.GetComponent<PlayerTransitionID>().playerIDTransition = inPut;
            //On désigne la scène où déplacer le joueur (le joueur n'est pas détruit en load)
            Scene sceneToLoad = SceneManager.GetSceneByName(outPut);
                       
            SceneManager.LoadScene(outPut);
        }
    }

    

}
