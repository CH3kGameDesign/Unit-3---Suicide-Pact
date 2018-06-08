using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoints : MonoBehaviour {

    public GameObject gameManager;          //To Add Points To Score
    public int scoreAmount;                 //How Much Landing Here Scores

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Movable")         //Check It Is Player
        gameManager.GetComponent<ScoreSystem>().scorePoints += scoreAmount;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Movable")         //Check It Is Player
            gameManager.GetComponent<ScoreSystem>().scorePoints -= scoreAmount;
    }
}
