using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {

    /*
        WHAT SCRIPT DOES:
        -   Everything On The Main Menu (Except Camera Rotation)
        -   Loads Progress On Start
        -   Sets number of Levels in GameProgress.levelComplete on Start
    */

	public GameObject startButton;              //The Button that starts the game, just used to be selected when the player presses 'B'
	public GameObject startPage;                //The Main set of main menu buttons
    public GameObject levels;                   //The Levels set of main menu buttons
	public GameObject level1;                   //The Button that loads level 1, just used to be selected when the player selects level select
    public GameObject level2;                   //Level 2 Button
    public GameObject level3;                   //Level 3 Button

    public Text level1Complete;                 //Levels Completed
    public Text level2Complete;                 //Levels Completed
    public Text level3Complete;                 //Levels Completed

    public GameObject level1EasterEgg;          //Easter Egg Collected
    public GameObject level2EasterEgg;          //Easter Egg Collected
    public GameObject level3EasterEgg;          //Easter Egg Collected

    //Load Level Completion / Set Number Of Levels In Save File
    private void Start()
    {
        SaveLoad.Load();
        if (GameProgress.levelComplete.Count < 2)
        {
            for (int i = 0; i < SceneManager.sceneCountInBuildSettings + 1; i++)
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
		startPage.SetActive (true);                                 //Enables Start Page
        levels.SetActive (false);                                   //Disables Levels Page
        EventSystem.current.SetSelectedGameObject (startButton);    //Set Cursor To Start
    }

    //Selects the Level Select Menu
	public void LevelSelect () {
		startPage.SetActive (false);                                //Disables Start Page
		levels.SetActive (true);                                    //Enables Levels Page
        EventSystem.current.SetSelectedGameObject(level1);          //Set Cursor To Level1
        //Check Level1 Progress and change UI accordingly
        if (GameProgress.levelComplete[1] > 0)
        {
            Debug.Log("Complete");
            level1Complete.text = "Completed";
            if (GameProgress.levelComplete[1] == 2)
            {
                level1EasterEgg.SetActive(true);
            }
        }
        //Disables Next Levels If Level Is Incomplete
        else
        {
            level2.SetActive(false);
            level2Complete.enabled = false;
            level3.SetActive(false);
            level3Complete.enabled = false;
        }
        //Check Level2 Progress and change UI accordingly
        if (GameProgress.levelComplete[2] > 0)
        {
            level2Complete.text = "Completed";
            if (GameProgress.levelComplete[2] == 2)
            {
                level2EasterEgg.SetActive(true);
            }
        }
        //Disables Next Levels If Level Is Incomplete
        else
        {
            level3.SetActive(false);
            level3Complete.enabled = false;
        }
        //Check Level3 Progress and change UI accordingly
        if (GameProgress.levelComplete[3] > 0)
        {
            level3Complete.text = "Completed";
            if (GameProgress.levelComplete[3] == 2)
            {
                level3EasterEgg.SetActive(true);
            }
        }
        
    }

    //Starting selected level
	public void SelectingLevel (int loadSceneIndex) {
		SceneManager.LoadScene (loadSceneIndex);
	}

    //Credits
    public void Credits()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    //Reset Progress
    public void ResetProgress()
    {
        GameProgress.levelComplete = new List<int>();
        SaveLoad.ResetProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    //Quit Game
    public void QuitGame()
    {
        Application.Quit();
    }


}
