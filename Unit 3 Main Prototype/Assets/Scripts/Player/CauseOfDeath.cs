using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseOfDeath : MonoBehaviour {

	public GameObject yreset;                       //Lowest Point the Player Can Go
	public GameObject playerModel;                  //Player Model
	public GameObject cameraCorrection;             //CharCorrection

    public Material deadMaterial;                   //Dead Material
    private Material[] deadMaterials;               //List of Dead Materials

	private Vector3 spikeDeathPos;                  //Keep Player Attached To Spikes

	//////////////////////////////////////////
	// What Death Does
	public void Death () {
		if (GetComponent<Movement> ().notdead) {
			//Enable Ragdoll-esque motion
			playerModel.transform.up = cameraCorrection.transform.forward;
			//playerModel.transform.eulerAngles = new Vector3 (90, 0, 0);
			GetComponent<Rigidbody> ().freezeRotation = false;

            //Let the world know you're dead
			GetComponent<Movement> ().notdead = false;
            GetComponentInChildren<FaceDirection>().notdead = false;

            //Make the Player Look Dead
            deadMaterials = GetComponentInChildren<MeshRenderer>().materials;
            for (int i = 0; i < GetComponentInChildren<MeshRenderer>().materials.Length; i++)
            {
                deadMaterials[i] = deadMaterial;
            }
            GetComponentInChildren<MeshRenderer>().materials = deadMaterials;
        }
		return;
	}

	//////////////////////////////////////////
	void OnTriggerEnter (Collider col) {
		//if (GetComponent<Movement> ().notdead == true) {
			 //Death By Drowning
			if (col.gameObject.name == "Waste") {
				Death ();
			}

            //Death By Hook
			if (col.gameObject.name == "HookPlayerPos") {
				col.gameObject.GetComponentInParent<Rigidbody>().AddForce (transform.forward * 10);
				Death ();
			}

            //Death By Spikes
			if (col.gameObject.name == "SpikeWall") {
				spikeDeathPos = transform.position;
				Death ();
			}

		//}
	}
	//////////////////////////////////////////
	void OnTriggerStay (Collider col) {
        //Stick To Hook
		if (col.gameObject.name == "HookPlayerPos") {
			transform.position = col.gameObject.transform.position;
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			GetComponent<Rigidbody> ().freezeRotation = true;
		}
        //Stick To Spikes
        if (col.gameObject.name == "SpikeWall") {
			transform.position = spikeDeathPos;
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			GetComponent<Rigidbody> ().freezeRotation = true;
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
