using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour {

	public Text FINISH;
	public Text finishButton;
	public bool levelFinished = false;

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
				FINISH.text = "Next Level Loading...";
				finishButton.text = " ";
				levelFinished = false;
			}
			if (Input.GetKeyDown(KeyCode.JoystickButton3)) {
				FINISH.text = "Next Level Loading...";
				finishButton.text = " ";
				levelFinished = false;
			}
		}
	}
}
