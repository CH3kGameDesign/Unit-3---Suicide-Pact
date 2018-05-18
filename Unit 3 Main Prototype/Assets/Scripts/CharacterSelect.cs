using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {

	public Text charSelectText;
	public Image deadBG;
	public Text deadText;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	public GameObject player1cam;
	public GameObject player2cam;
	public GameObject player3cam;
	public GameObject player4cam;

	public GameObject player1model;
	public GameObject player2model;
	public GameObject player3model;
	public GameObject player4model;

	public float charselect = 1;

	/////////////////////////////////////

	// Ensure Starting Variables Are Correct
	void Start () {
		charSelectText.text = "Player 1";
		player1.GetComponent<Movement>().enabled = true;
		player2.GetComponent<Movement>().enabled = false;
		player3.GetComponent<Movement>().enabled = false;
		player4.GetComponent<Movement>().enabled = false;

		player1cam.SetActive(true);
		player2cam.SetActive(false);
		player3cam.SetActive(false);
		player4cam.SetActive(false);

	}

	/////////////////////////////////////

	// Update is called once per frame
	void Update () {
		//CharacterSelect
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			charselect += 1;
			changecharacter ();
		}
		if (Input.GetKeyDown (KeyCode.JoystickButton5)) {
			charselect += 1;
			changecharacter ();
		}
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			charselect -= 1;
			changecharacter ();
		}
		if (Input.GetKeyDown (KeyCode.JoystickButton4)) {
			charselect -= 1;
			changecharacter ();
		}

		if (charselect > 4) {
			charselect = 1;
			changecharacter ();
		}
		if (charselect < 1) {
			charselect = 4;
			changecharacter ();
		}

		/////////////////////////////////////

		//Dead Text
		if (charselect == 1) {
			if (player1.GetComponent<Movement> ().notdead == false) {
				//Show Dead Text
				deadText.text = "DEAD";
				deadBG.enabled = true;

			} else {
				//Hide Dead Text
				deadText.text = " ";
				deadBG.enabled = false;

			}
		}
		if (charselect == 2) {
			if (player2.GetComponent<Movement> ().notdead == false) {
				//Show Dead Text
				deadText.text = "DEAD";
				deadBG.enabled = true;

			} else {
				//Hide Dead Text
				deadText.text = " ";
				deadBG.enabled = false;

			}
		}
		if (charselect == 3) {
			if (player3.GetComponent<Movement> ().notdead == false) {
				//Show Dead Text
				deadText.text = "DEAD";
				deadBG.enabled = true;

			} else {
				//Hide Dead Text
				deadText.text = " ";
				deadBG.enabled = false;

			}
		}
		if (charselect == 4) {
			if (player4.GetComponent<Movement> ().notdead == false) {
				//Show Dead Text
				deadText.text = "DEAD";
				deadBG.enabled = true;

			} else {
				//Hide Dead Text
				deadText.text = " ";
				deadBG.enabled = false;

			}
		}

	}

	/// //////////////////////////////////////////////

	void changecharacter () {
		if (charselect == 1) {
			charSelectText.text = "Player 1";
			player1.GetComponent<Movement>().enabled = true;
			player2.GetComponent<Movement>().enabled = false;
			player3.GetComponent<Movement>().enabled = false;
			player4.GetComponent<Movement>().enabled = false;

			player1cam.SetActive(true);
			player2cam.SetActive(false);
			player3cam.SetActive(false);
			player4cam.SetActive(false);
		}
		if (charselect == 2) {
			charSelectText.text = "Player 2";
			player1.GetComponent<Movement>().enabled = false;
			player2.GetComponent<Movement>().enabled = true;
			player3.GetComponent<Movement>().enabled = false;
			player4.GetComponent<Movement>().enabled = false;

			player1cam.SetActive(false);
			player2cam.SetActive(true);
			player3cam.SetActive(false);
			player4cam.SetActive(false);
		}
		if (charselect == 3) {
			charSelectText.text = "Player 3";
			player1.GetComponent<Movement>().enabled = false;
			player2.GetComponent<Movement>().enabled = false;
			player3.GetComponent<Movement>().enabled = true;
			player4.GetComponent<Movement>().enabled = false;

			player1cam.SetActive(false);
			player2cam.SetActive(false);
			player3cam.SetActive(true);
			player4cam.SetActive(false);
		}
		if (charselect == 4) {
			charSelectText.text = "Player 4";
			player1.GetComponent<Movement>().enabled = false;
			player2.GetComponent<Movement>().enabled = false;
			player3.GetComponent<Movement>().enabled = false;
			player4.GetComponent<Movement>().enabled = true;

			player1cam.SetActive(false);
			player2cam.SetActive(false);
			player3cam.SetActive(false);
			player4cam.SetActive(true);
		}

	}
}
