using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoints : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Score Points If Player Enters
    -   Remove said Points if Player Leaves
    */

    public GameObject gameManager;          //To Add Points To Score
    public int scoreAmount;                 //How Much Landing Here Scores

    //Score Points
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Movable")         //Check It Is Player
        gameManager.GetComponent<ScoreSystem>().scorePoints += scoreAmount;
    }
    //Remove Points
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Movable")         //Check It Is Player
            gameManager.GetComponent<ScoreSystem>().scorePoints -= scoreAmount;
    }
}
