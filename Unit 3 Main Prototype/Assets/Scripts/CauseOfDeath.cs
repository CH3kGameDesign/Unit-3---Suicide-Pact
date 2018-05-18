using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseOfDeath : MonoBehaviour {

	public GameObject yreset;
	public GameObject playerModel;
	public GameObject cameraCorrection;

	//////////////////////////////////////////
	// What Death Does
	void Death () {
		if (GetComponent<Movement> ().notdead) {
			//Enable Ragdoll-esque motion
			playerModel.transform.up = cameraCorrection.transform.forward;
			//playerModel.transform.eulerAngles = new Vector3 (90, 0, 0);
			GetComponent<Rigidbody> ().freezeRotation = false;
			GetComponent<Movement> ().notdead = false;
		}
		return;
	}

	//////////////////////////////////////////
	void OnCollisionEnter (Collision col) {
		if (GetComponent<Movement> ().notdead == true) {
			// Death By Drowning
			if (col.gameObject.name == "Waste") {
				Death ();
			}
		}
	}

	//////////////////////////////////////////
	void Update () {
		if (GetComponent<Movement> ().notdead == true) {
			// Death By Falling Beyond Scene
			if ((transform.position.y) < (yreset.transform.position.y)) {
				Death ();
			}

			//////////////////////////////////////////
			// Death By Spontaneous Suicide

			if (GetComponent<Movement> ().enabled == true) {

				if (Input.GetKeyDown (KeyCode.Q)) {
					Death ();
				}
				if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
					Death ();
				}
			}
		}
	}

	//////////////////////////////////////////
}
