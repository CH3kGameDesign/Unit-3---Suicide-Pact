using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

	public GameObject startButton;              //The Button that starts the game, just used to be selected when the player presses 'B'
	public GameObject startPage;                //The Main set of main menu buttons
    public GameObject levels;                   //The Levels set of main menu buttons
	public GameObject level1;                   //The Button that loads level 1, just used to be selected when the player selects level select

    void Update () {
        //Input for Go Back
		if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Escape)) {
			ResetMenu ();
		}
	}

    //Start the First Level
	public void StartGame () {
		int nextSceneIndex = SceneManager.GetActiveScene ().buildIndex + 1;
		if (SceneManager.sceneCountInBuildSettings > nextSceneIndex) {
			SceneManager.LoadScene (nextSceneIndex);
		}
	}

    //Go Back
    public void ResetMenu () {
		startPage.SetActive (true);
		levels.SetActive (false);
		EventSystem.current.SetSelectedGameObject (startButton);
	}

    //Selects the Level Select Menu
	public void LevelSelect () {
		startPage.SetActive (false);
		levels.SetActive (true);
		EventSystem.current.SetSelectedGameObject (level1);
	}

    //Starting selected level
	public void SelectingLevel (int loadSceneIndex) {
		SceneManager.LoadScene (loadSceneIndex);
	}

    //Quit Game
    public void QuitGame()
    {
        Application.Quit();
    }


}
