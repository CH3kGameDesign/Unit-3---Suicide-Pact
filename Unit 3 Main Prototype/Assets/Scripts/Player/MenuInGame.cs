using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Call In Game Menu
    -   Does All That Button Stuff
    -   Cursor Enable/Disable
    */

    public GameObject inGameText;           //InGame NonMenu Text
	public GameObject menuText;             //InGame Menu Text
	public GameObject resume;               //Resume Button

	private bool paused = false;            //Whether Paused or Not


    //Calling Menu
    void Update () {
		if (Input.GetKeyDown (KeyCode.JoystickButton7) || Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape)) {
			if (!paused) {
				MenuOpen ();
				return;
			}
			if (paused) {
				MenuClose ();
				return;
			}
		}
	}

	public void MenuOpen() {
        //Disable InGame Stuff
		GetComponent<CharacterSelect>().enabled = false;
		GetComponent<CharacterSelect>().disablecharacters ();
		inGameText.SetActive (false);
        //Enable Menu
		menuText.SetActive (true);
		EventSystem.current.SetSelectedGameObject (resume);
        //Cursor Enable
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        paused = true;
    }

	public void MenuClose() {
        //Enable Game Stuff
		GetComponent<CharacterSelect>().enabled = true;
		GetComponent<CharacterSelect> ().changecharacter ();
		inGameText.SetActive (true);
        //Disable Menu
		menuText.SetActive (false);
        //Cursor Disable
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        paused = false;
    }


    //Restart
	public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Main Menu
	public void MainMenu() {
		SceneManager.LoadScene (0);
	}
}
