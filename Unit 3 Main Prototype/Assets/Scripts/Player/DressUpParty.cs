using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressUpParty : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Change Player Hats/Models
    -   Resets Player Hats/Models On Respawn
    */

    public List<GameObject> hatList = new List<GameObject>();           //List of Hat People
	public GameObject Player1;                                          //Self Explanatory
	public GameObject Player2;                                          //Self Explanatory
    public GameObject Player3;                                          //Self Explanatory
    public GameObject Player4;                                          //Self Explanatory

    private int Player1Hat;                                             //Keep Track of what Player1 is Wearing
	private int Player2Hat;                                             //Keep Track of what Player2 is Wearing
    private int Player3Hat;                                             //Keep Track of what Player3 is Wearing
    private int Player4Hat;                                             //Keep Track of what Player4 is Wearing

    private int Player1HatPast;                                         //Keep Track of what Player1 wore last      ONLY FOR CHANGING ON RESPAWN
    private int Player2HatPast;                                         //Keep Track of what Player2 wore last      ONLY FOR CHANGING ON RESPAWN
    private int Player3HatPast;                                         //Keep Track of what Player3 wore last      ONLY FOR CHANGING ON RESPAWN
    private int Player4HatPast;                                         //Keep Track of what Player4 wore last      ONLY FOR CHANGING ON RESPAWN

    private float hatChange;                                            //To Check which character's hat to change  USED FOR CHANGING ON RESPAWN ANNND RESETTING PLAYER MATERIALS


	// Use this for initialization
	void Start () {
		//Start Variables
		Player1Hat = -1;
		Player2Hat = -1;
		Player3Hat = -1;
		Player4Hat = -1;

        Player1HatPast = -1;
		Player2HatPast = -1;
		Player3HatPast = -1;
		Player4HatPast = -1;
        //Select First Hats
		Player1HatSelect ();
		Player2HatSelect ();
		Player3HatSelect ();
		Player4HatSelect ();
	}

    //Change Player 1 Hat
	void Player1HatSelect () {
        //Randomize Hat
		Player1Hat = Random.Range (0, hatList.Count);
        //Check Hat is not in use
		if (Player1Hat == Player2Hat || Player1Hat == Player3Hat || Player1Hat == Player4Hat || Player1Hat == Player1HatPast) {
            //ReRandomize Hat
			Player1HatSelect();
		}

        //Set Past Hat Variable
		Player1HatPast = Player1Hat;
        //Change Hat
		Player1.GetComponent<MeshFilter> ().sharedMesh = hatList [Player1Hat].GetComponent<MeshFilter>().sharedMesh;
		Player1.GetComponent<MeshRenderer>().sharedMaterials = hatList [Player1Hat].GetComponent<MeshRenderer>().sharedMaterials;

	}

    //Change Player 2 Hat
    void Player2HatSelect () {
        //Randomize Hat
        Player2Hat = Random.Range (0, hatList.Count);
        //Check Hat is not in use
        if (Player2Hat == Player1Hat || Player2Hat == Player3Hat || Player2Hat == Player4Hat || Player2Hat == Player2HatPast) {
            //ReRandomize Hat
            Player2HatSelect();
		}

        //Set Past Hat Variable
        Player2HatPast = Player2Hat;
        //Change Hat
        Player2.GetComponent<MeshFilter> ().sharedMesh = hatList [Player2Hat].GetComponent<MeshFilter>().sharedMesh;
		Player2.GetComponent<MeshRenderer>().sharedMaterials = hatList [Player2Hat].GetComponent<MeshRenderer>().sharedMaterials;

	}

    //Change Player 3 Hat
    void Player3HatSelect () {
        //Randomize Hat
        Player3Hat = Random.Range (0, hatList.Count);
        //Check Hat is not in use
        if (Player3Hat == Player1Hat || Player3Hat == Player2Hat || Player3Hat == Player4Hat || Player3Hat == Player3HatPast) {
            //ReRandomize Hat
            Player3HatSelect();
		}

        //Set Past Hat Variable
        Player3HatPast = Player3Hat;
        //Change Hat
        Player3.GetComponent<MeshFilter> ().sharedMesh = hatList [Player3Hat].GetComponent<MeshFilter>().sharedMesh;
		Player3.GetComponent<MeshRenderer>().sharedMaterials = hatList [Player3Hat].GetComponent<MeshRenderer>().sharedMaterials;

	}

    //Change Player 4 Hat
    void Player4HatSelect() {
        //Randomize Hat
        Player4Hat = Random.Range (0, hatList.Count);
        //Check Hat is not in use
        if (Player4Hat == Player1Hat || Player4Hat == Player2Hat || Player4Hat == Player3Hat || Player4Hat == Player4HatPast) {
            //ReRandomize Hat
            Player4HatSelect();
		}

        //Set Past Hat Variable
        Player4HatPast = Player4Hat;
        //Change Hat
        Player4.GetComponent<MeshFilter> ().sharedMesh = hatList [Player4Hat].GetComponent<MeshFilter>().sharedMesh;
		Player4.GetComponent<MeshRenderer>().sharedMaterials = hatList [Player4Hat].GetComponent<MeshRenderer>().sharedMaterials;

	}

    //Change Hat On Respawn
	public void HatReset() {
		hatChange = GetComponent<CharacterSelect> ().charselect;
		if (hatChange == 1) {
			Player1HatSelect ();
		}
		if (hatChange == 2) {
			
			Player2HatSelect ();
		}
		if (hatChange == 3) {
			
			Player3HatSelect ();
		}
		if (hatChange == 4) {
			
			Player4HatSelect ();
		}
	}

    //Reset Hat Colour On Respawn
    public void HatColourReset()
    {
        hatChange = GetComponent<CharacterSelect>().charselect;
        if (hatChange == 1)
        {
            Player1.GetComponent<MeshRenderer>().sharedMaterials = hatList[Player1Hat].GetComponent<MeshRenderer>().sharedMaterials;
        }
        if (hatChange == 2)
        {

            Player2.GetComponent<MeshRenderer>().sharedMaterials = hatList[Player2Hat].GetComponent<MeshRenderer>().sharedMaterials;
        }
        if (hatChange == 3)
        {

            Player3.GetComponent<MeshRenderer>().sharedMaterials = hatList[Player3Hat].GetComponent<MeshRenderer>().sharedMaterials;
        }
        if (hatChange == 4)
        {

            Player4.GetComponent<MeshRenderer>().sharedMaterials = hatList[Player4Hat].GetComponent<MeshRenderer>().sharedMaterials;
        }
    }

}
