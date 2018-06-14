using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Finishes The Level
    -   Changes GameProgress
    -   Loads Next Scene
    */

    public Text FINISH;						//TextObject That says Finished
	public Text finishButton;				//TextObject That tells you What To Press
    
	public bool levelFinished = false;		//Have you finished?
    public GameObject players;              //Players Controller GameObject
    public GameObject fireworks;            //Legit Fireworks
    public GameObject easterEgg;            //Easter Egg

    void Start () {
        //Start Variables
		FINISH.text = " ";
		finishButton.text = " ";
		levelFinished = false;
	}

    //Finish Level
    void OnTriggerEnter() {
		FINISH.text = "YOU COMPLETED THAT ARBITRARY TASK!!";
        Instantiate(fireworks, transform.position, Quaternion.Euler (-90,0,0));
        if (GameProgress.levelComplete[SceneManager.GetActiveScene().buildIndex] == 0)
            GameProgress.levelComplete[SceneManager.GetActiveScene().buildIndex] = 1;
        if (easterEgg.GetComponent<EasterEgg>().found == true)
            GameProgress.levelComplete[SceneManager.GetActiveScene().buildIndex] = 2;
        SaveLoad.Save();
        //Display which Controls to use
        if (players.GetComponent<CharacterSelect>().xboxController)
        {
            finishButton.text = "Press 'A' To Continue";
        } else
        {
            finishButton.text = "Press 'Space' To Continue";
        }
        levelFinished = true;
    }
	
	// Update is called once per frame
	void Update () {
        //Go To Next Level Input
		if (levelFinished) {
			if (Input.GetKeyDown(KeyCode.Space)) {
				NextLevel ();
			}
			if (Input.GetKeyDown(KeyCode.JoystickButton0)) {
				NextLevel ();
			}
		}
    }

    //Go To Next Level
	void NextLevel () {
		FINISH.text = "Next Level Loading...";
		finishButton.text = " ";
		levelFinished = false;
		//Load Next Scene
		int nextSceneIndex = SceneManager.GetActiveScene ().buildIndex + 1;
		if (SceneManager.sceneCountInBuildSettings > nextSceneIndex) {
			SceneManager.LoadScene (nextSceneIndex);
		} else SceneManager.LoadScene(0);
    }
}
