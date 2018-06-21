using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectManager : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Changes Characters
    -   Display Controls
    -   Display DeadText If Dead
    -   Change Cameras On MenuPress
    */

	public GameObject player1;                  //Self Explanatory
	public GameObject player2;                  //Self Explanatory
    public GameObject player3;                  //Self Explanatory
    public GameObject player4;                  //Self Explanatory

    public GameObject player1cam;               //Player 1 Camera Stuff
    public GameObject player2cam;               //Player 2 Camera Stuff
    public GameObject player3cam;               //Player 3 Camera Stuff
    public GameObject player4cam;               //Player 4 Camera Stuff
    public GameObject menucam;                  //In-Game Menu Camera

    private float player1char;                    //Player1's Character
    private float player2char;                    //Player2's Character
    private float player3char;                    //Player3's Character
    private float player4char;                    //Player4's Character


    //---------------------------------------------------------------------

    // Ensure Starting Variables Are Correct
    void Start () {
        //Respawn Location and Rotations
		player1.GetComponent<Movement> ().respawn = player1.transform.position;
		player1.GetComponent<Movement> ().respawnRotation = player1.transform.rotation;

		player2.GetComponent<Movement> ().respawn = player2.transform.position;
		player2.GetComponent<Movement> ().respawnRotation = player2.transform.rotation;

		player3.GetComponent<Movement> ().respawn = player3.transform.position;
		player3.GetComponent<Movement> ().respawnRotation = player3.transform.rotation;

		player4.GetComponent<Movement> ().respawn = player4.transform.position;
		player4.GetComponent<Movement> ().respawnRotation = player4.transform.rotation;
        

        //changecharacter();
	}

	//---------------------------------------------------------------------

	public void changecharacter () {
        //Select Character
        player1char = this.GetComponent<CharacterSelect1>().charselect;
        player2char = this.GetComponent<CharacterSelect2>().charselect;

        if (player1char == 1 || player2char == 1)
        {
            player1.GetComponent<Movement>().enabled = true;
            player1cam.SetActive(true);
        }
        else
        {
            player1.GetComponent<Movement>().enabled = false;
            player1cam.SetActive(false);
        }

        if (player1char == 2 || player2char == 2)
        {
            player2.GetComponent<Movement>().enabled = true;
            player2cam.SetActive(true);
        }
        else
        {
            player2.GetComponent<Movement>().enabled = false;
            player2cam.SetActive(false);
        }

        if (player1char == 3 || player2char == 3)
        {
            player3.GetComponent<Movement>().enabled = true;
            player3cam.SetActive(true);
        }
        else
        {
            player3.GetComponent<Movement>().enabled = false;
            player3cam.SetActive(false);
        }

        if (player1char == 4 || player2char == 4)
        {
            player4.GetComponent<Movement>().enabled = true;
            player4cam.SetActive(true);
        }
        else
        {
            player4.GetComponent<Movement>().enabled = false;
            player4cam.SetActive(false);
        }


        /*
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
                    menucam.SetActive(false);

                    //Halves the viewport
                    player1cam.GetComponentInChildren<Camera>().rect = new Rect(Screen.width/2, 0, 0.5f, 1);
                }
                */

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
