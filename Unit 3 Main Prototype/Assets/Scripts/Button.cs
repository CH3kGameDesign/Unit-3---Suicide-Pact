using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public GameObject door;
	public GameObject launchPad;
	public GameObject powerLine;
	public Material powerOff;
	public Material powerOn;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter() {
		if (launchPad) {
			launchPad.GetComponent<LaunchPad> ().launch = true;
		}
	}

	void OnCollisionStay() {
		if (door) {
			door.SetActive (false);
		}
		powerLine.GetComponent<MeshRenderer>().material = powerOn;
	}

	void OnCollisionExit() {
		if (door) {
			door.SetActive (true);
		}
		powerLine.GetComponent<MeshRenderer>().material = powerOff;
	}
}
