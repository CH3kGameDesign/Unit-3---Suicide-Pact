using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

    public Text scoreText;
    public GameObject easterEgg;
    public int scorePoints;

	// Use this for initialization
	void Start () {
        scorePoints = 0;
    }
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + scorePoints;

        if (scorePoints > 999)
            easterEgg.transform.position = new Vector3(1.5f, 14.5f, -17.75f);
        else
            easterEgg.transform.position = new Vector3(0, 5, 30);

    }
}
