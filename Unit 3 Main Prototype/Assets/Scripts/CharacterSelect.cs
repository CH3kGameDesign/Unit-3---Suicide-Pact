using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {

	public Text charSelectText;
	public Image deadBG;
	public Text deadText;
	public Text controlsPC;
	public Text controlsXBOX;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

	public GameObject player1cam;
	public GameObject player2cam;
	public GameObject player3cam;
	public GameObject player4cam;

	public float charselect = 1;

	public bool xboxController;

	//---------------------------------------------------------------------

	// Ensure Starting Variables Are Correct
	void Start () {

		player1.GetComponent<Movement> ().respawn = player1.transform.position;
		player1.GetComponent<Movement> ().respawnRotation = player1.transform.rotation;

		player2.GetComponent<Movement> ().respawn = player2.transform.position;
		player2.GetComponent<Movement> ().respawnRotation = player2.transform.rotation;

		player3.GetComponent<Movement> ().respawn = player3.transform.position;
		player3.GetComponent<Movement> ().respawnRotation = player3.transform.rotation;

		player4.GetComponent<Movement> ().respawn = player4.transform.position;
		player4.GetComponent<Movement> ().respawnRotation = player4.transform.rotation;

		charSelectText.text = "Player 1";
		player1.GetComponent<Movement>().enabled = true;
		player2.GetComponent<Movement>().enabled = false;
		player3.GetComponent<Movement>().enabled = false;
		player4.GetComponent<Movement>().enabled = false;

		player1cam.SetActive(true);
		player2cam.SetActive(false);
		player3cam.SetActive(false);
		player4cam.SetActive(false);

		controlsPC.enabled = true;
		controlsXBOX.enabled = false;
	}

	//---------------------------------------------------------------------

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

		//---------------------------------------------------------------------

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
		//Check What Controls were used
		if (Input.GetKeyDown (KeyCode.Space)) {
			xboxController = false;
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			xboxController = false;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			xboxController = false;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			xboxController = false;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			xboxController = false;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			xboxController = false;
		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			xboxController = false;
		}
		if (Input.GetAxis ("MouseXCheck") != 0) {
			xboxController = false;
		}
		if (Input.GetKeyDown (KeyCode.JoystickButton0)) {
			xboxController = true;
		}
		if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
			xboxController = true;
		}
		if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
			xboxController = true;
		}
		if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
			xboxController = true;
		}
		if (Input.GetKeyDown (KeyCode.JoystickButton4)) {
			xboxController = true;
		}
		if (Input.GetKeyDown (KeyCode.JoystickButton5)) {
			xboxController = true;
		}
		if (Input.GetAxis ("ControllerHorizontalCheck") != 0) {
			xboxController = true;
		}
		if (Input.GetAxis ("ControllerVerticalCheck") != 0) {
			xboxController = true;
		}
		if (Input.GetAxis ("ControllerRXCheck") != 0) {
			xboxController = true;
		}
		if (Input.GetAxis ("ControllerRYCheck") != 0) {
			xboxController = true;
		}


		//Display Controls
		if (xboxController) {
			controlsPC.enabled = false;
			controlsXBOX.enabled = true;
		} else {
			controlsPC.enabled = true;
			controlsXBOX.enabled = false;
		}

	}

	//---------------------------------------------------------------------

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
