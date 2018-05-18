using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public GameObject door;
	public GameObject powerLine;
	public Material powerOff;
	public Material powerOn;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionStay() {
		door.SetActive(false);
		powerLine.GetComponent<MeshRenderer>().material = powerOn;
	}

	void OnCollisionExit() {
		door.SetActive(true);
		powerLine.GetComponent<MeshRenderer>().material = powerOff;
	}
}
