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
    public GameObject level2;                   //Level 2 Button
    public GameObject level3;                   //Level 3 Button

    public Text level1Complete;                 //Levels Completed
    public Text level2Complete;                 //Levels Completed
    public Text level3Complete;                 //Levels Completed

    //Load Level Completion / Set Number Of Levels In Save File
    private void Start()
    {
        SaveLoad.Load();
        if (GameProgress.levelComplete.Count < 2)
        {
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                GameProgress.levelComplete.Add(0);
            }
        }
    }

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
        if (GameProgress.levelComplete[1] == 1)
        {
            Debug.Log("Complete");
            level1Complete.text = "Completed";
        } else
        {
            level2.SetActive(false);
            level2Complete.enabled = false;
            level3.SetActive(false);
            level3Complete.enabled = false;
        }
        if (GameProgress.levelComplete[2] == 1)
        {
            level2Complete.text = "Completed";
        } else
        {
            level3.SetActive(false);
            level3Complete.enabled = false;
        }
        if (GameProgress.levelComplete[3] == 1)
        {
            level3Complete.text = "Completed";
        }
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
