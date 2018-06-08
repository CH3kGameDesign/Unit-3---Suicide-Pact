using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

    public Text scoreText;                              //Display How Much You Scored
    public GameObject easterEgg;                        //EASTEEER EGGGU
    public int scorePoints;                             //How Much You Scored

	
	void Start () {
        scorePoints = 0;                                //Start at 0
    }
	
	
	void Update () {
        scoreText.text = "Score: " + scorePoints;       //Display Score

        if (scorePoints > 999)
            easterEgg.transform.position = new Vector3(1.5f, 14.5f, -17.75f);
        else
            easterEgg.transform.position = new Vector3(0, 5, 30);

    }
}
