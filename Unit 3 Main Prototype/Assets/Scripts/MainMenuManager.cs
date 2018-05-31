using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public GameObject startButton;
	public GameObject startPage;
	public GameObject levels;
	public GameObject level1;

	void Update () {
		if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Escape)) {
			ResetMenu ();
		}
	}

	public void StartGame () {
		int nextSceneIndex = SceneManager.GetActiveScene ().buildIndex + 1;
		if (SceneManager.sceneCountInBuildSettings > nextSceneIndex) {
			SceneManager.LoadScene (nextSceneIndex);
		}
	}


	public void ResetMenu () {
		startPage.SetActive (true);
		levels.SetActive (false);
		EventSystem.current.SetSelectedGameObject (startButton);
	}

	public void LevelSelect () {
		startPage.SetActive (false);
		levels.SetActive (true);
		EventSystem.current.SetSelectedGameObject (level1);
	}

	public void SelectingLevel (int loadSceneIndex) {
		SceneManager.LoadScene (loadSceneIndex);
	}



}
