using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoints : MonoBehaviour {

    public GameObject gameManager;
    public int scoreAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Movable")
        gameManager.GetComponent<ScoreSystem>().scorePoints += scoreAmount;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Movable")
            gameManager.GetComponent<ScoreSystem>().scorePoints -= scoreAmount;
    }
}
