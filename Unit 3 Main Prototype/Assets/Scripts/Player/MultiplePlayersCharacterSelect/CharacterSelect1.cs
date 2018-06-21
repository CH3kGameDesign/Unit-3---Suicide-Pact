﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect1 : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Changes Characters
    -   Display Controls
    -   Display DeadText If Dead
    -   Change Cameras On MenuPress
    */


    public Text charSelectText;                 //Selected Character Text
	public Image deadBG;                        //Dead Text Background
	public Text deadText;                       //Dead Text
	public Text controlsPC;                     //PC Controls Text
	public Text controlsXBOX;                   //Xbox Controls Text

	public GameObject player1;                  //Self Explanatory
	public GameObject player2;                  //Self Explanatory
    public GameObject player3;                  //Self Explanatory
    public GameObject player4;                  //Self Explanatory

    public GameObject player1cam;               //Player 1 Camera Stuff
    public GameObject player2cam;               //Player 2 Camera Stuff
    public GameObject player3cam;               //Player 3 Camera Stuff
    public GameObject player4cam;               //Player 4 Camera Stuff
    public GameObject menucam;                  //In-Game Menu Camera

    public float charselect = 1;                //Selected Character

	public bool xboxController;                 //Whether using Xbox Controller

	//---------------------------------------------------------------------

	// Ensure Starting Variables Are Correct
	void Start () {

		controlsPC.enabled = true;
		controlsXBOX.enabled = false;

        changecharacter();
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

        //Ensure Characters Don't Exceed 4 or Reach 0
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

	public void changecharacter () {
        //Select Character
        if (charselect == 1) {
			charSelectText.text = "Player 1";

            //Halves the viewport
            player1cam.GetComponentInChildren<Camera>().rect = new Rect(0, 0, 0.5f, 1);
		}
		if (charselect == 2) {
			charSelectText.text = "Player 2";

            //Halves the viewport
            player2cam.GetComponentInChildren<Camera>().rect = new Rect(0, 0, 0.5f, 1);
        }
		if (charselect == 3) {
			charSelectText.text = "Player 3";

            //Halves the viewport
            player3cam.GetComponentInChildren<Camera>().rect = new Rect(0, 0, 0.5f, 1);
        }
		if (charselect == 4) {
			charSelectText.text = "Player 4";

            //Halves the viewport
            player4cam.GetComponentInChildren<Camera>().rect = new Rect(0, 0, 0.5f, 1);
        }
        GetComponent<CharacterSelectManager>().changecharacter();
    }

    //Disable Characters    FOR MENU
	public void disablecharacters () {
		player1.GetComponent<Movement> ().enabled = false;
		player2.GetComponent<Movement> ().enabled = false;
		player3.GetComponent<Movement> ().enabled = false;
		player4.GetComponent<Movement> ().enabled = false;

		player1cam.SetActive(false);
		player2cam.SetActive(false);
		player3cam.SetActive(false);
		player4cam.SetActive(false);
		menucam.SetActive(true);
	}
}
