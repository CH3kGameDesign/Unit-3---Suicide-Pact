using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

	public Text FINISH;						//TextObject That says Finished
	public Text finishButton;				//TextObject That tells you What To Press
	public bool levelFinished = false;		//Have you finished?

	void Start () {
		FINISH.text = " ";
		finishButton.text = " ";
		levelFinished = false;
	}

	void OnCollisionEnter() {
		FINISH.text = "YOU COMPLETED THAT ARBITRARY TASK!!";
		finishButton.text = "Respawn To Continue";
		levelFinished = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (levelFinished) {
			if (Input.GetKeyDown(KeyCode.R)) {
				NextLevel ();
			}
			if (Input.GetKeyDown(KeyCode.JoystickButton3)) {
				NextLevel ();
			}
		}
	}
	void NextLevel () {
		FINISH.text = "Next Level Loading...";
		finishButton.text = " ";
		levelFinished = false;
		//Load Next Scene
		int nextSceneIndex = SceneManager.GetActiveScene ().buildIndex + 1;
		if (SceneManager.sceneCountInBuildSettings > nextSceneIndex) {
			SceneManager.LoadScene (nextSceneIndex);
		}
	}
}
