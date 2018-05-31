using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour {

	public GameObject inGameText;
	public GameObject menuText;
	public GameObject resume;

	private bool paused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Calling Menu
		if (Input.GetKeyDown (KeyCode.JoystickButton7) || Input.GetKeyDown (KeyCode.Return)) {
			if (!paused) {
				MenuOpen ();
				paused = true;
				return;
			}
			if (paused) {
				MenuClose ();
				paused = false;
				return;
			}
		}
	}

	public void MenuOpen() {
		GetComponent<CharacterSelect>().enabled = false;
		GetComponent<CharacterSelect>().disablecharacters ();
		inGameText.SetActive (false);
		menuText.SetActive (true);
		EventSystem.current.SetSelectedGameObject (resume);
	}

	public void MenuClose() {
		GetComponent<CharacterSelect>().enabled = true;
		GetComponent<CharacterSelect> ().changecharacter ();
		inGameText.SetActive (true);
		menuText.SetActive (false);
	}

	public void Restart() {
		Application.LoadLevel (Application.loadedLevel);
	}

	public void MainMenu() {
		SceneManager.LoadScene (0);
	}
}
