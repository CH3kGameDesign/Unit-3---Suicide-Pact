using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressUpParty : MonoBehaviour {

	public List<GameObject> hatList = new List<GameObject>();
	public GameObject Player1;
	public GameObject Player2;
	public GameObject Player3;
	public GameObject Player4;

	private int Player1Hat;
	private int Player2Hat;
	private int Player3Hat;
	private int Player4Hat;

	private float hatChange;


	// Use this for initialization
	void Start () {
		//Select First Hats
		Player1Hat = -1;
		Player2Hat = -1;
		Player3Hat = -1;
		Player4Hat = -1;

		Player1HatSelect ();
		Player2HatSelect ();
		Player3HatSelect ();
		Player4HatSelect ();
	}

	void Player1HatSelect () {
		Player1Hat = Random.Range (0, hatList.Count);
		if (Player1Hat == Player2Hat || Player1Hat == Player3Hat || Player1Hat == Player4Hat) {
			Player1HatSelect();
		}
		GameObject Hat = Instantiate (hatList [Player1Hat], Player1.transform.position + new Vector3 (0, 0.8f, 0), transform.rotation) as GameObject;
		Hat.transform.SetParent (Player1.transform);

	}

	void Player2HatSelect () {
		Player2Hat = Random.Range (0, hatList.Count);
		if (Player2Hat == Player1Hat || Player2Hat == Player3Hat || Player2Hat == Player4Hat) {
			Player2HatSelect();
		}
		GameObject Hat = Instantiate (hatList [Player2Hat], Player2.transform.position + new Vector3 (0, 0.8f, 0), transform.rotation) as GameObject;
		Hat.transform.SetParent (Player2.transform);

	}

	void Player3HatSelect () {
		Player3Hat = Random.Range (0, hatList.Count);
		if (Player3Hat == Player1Hat || Player3Hat == Player2Hat || Player3Hat == Player4Hat) {
			Player3HatSelect();
		}
		GameObject Hat = Instantiate (hatList [Player3Hat], Player3.transform.position + new Vector3 (0, 0.8f, 0), transform.rotation) as GameObject;
		Hat.transform.SetParent (Player3.transform);

	}

	void Player4HatSelect() {
		Player4Hat = Random.Range (0, hatList.Count);
		if (Player4Hat == Player1Hat || Player4Hat == Player2Hat || Player4Hat == Player3Hat) {
			Player4HatSelect();
		}
		GameObject Hat = Instantiate (hatList [Player4Hat], Player4.transform.position + new Vector3 (0, 0.8f, 0), transform.rotation) as GameObject;
		Hat.transform.SetParent (Player4.transform);

	}


	public void HatReset() {
		hatChange = GetComponent<CharacterSelect> ().charselect;
		if (hatChange == 1) {
			
			Player1HatSelect ();
		}
		if (hatChange == 2) {
			
			Player1HatSelect ();
		}
		if (hatChange == 3) {
			
			Player1HatSelect ();
		}
		if (hatChange == 4) {
			
			Player1HatSelect ();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
