using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public GameObject door;
	public GameObject launchPad;
	public GameObject powerLine;
	public GameObject movingPlatform;
	public Material powerOff;
	public Material powerOn;

	public float buttonCooldownLimit = 20;			//Time before buttonCoolDown does something
	private float buttonCooldown;					//Legit just for counting how long powerline should light for tall button press
	private bool buttonTall;						//Whether button is tall

	// Use this for initialization
	void Start () {
		buttonTall = false;
		buttonCooldown = 0;
	}

	void FixedUpdate () {
		if (buttonTall == true) {
			buttonCooldown++;
			if (buttonCooldown > buttonCooldownLimit) {
				powerLine.GetComponent<MeshRenderer>().material = powerOff;
			}
		}
	}

	void OnCollisionEnter() {
		if (launchPad) {
			launchPad.GetComponent<LaunchPad> ().launch = true;
		}
		if (movingPlatform) {
			movingPlatform.GetComponent<MovingPlatform> ().move = true;
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

	void OnTriggerStay(Collider obj) {
		if (obj.GetComponentInParent<Movement> ().enabled == true) {
			if (Input.GetKeyDown (KeyCode.E) || Input.GetKeyDown (KeyCode.JoystickButton2)) {
				if (launchPad) {
					launchPad.GetComponent<LaunchPad> ().launch = true;
				}
				if (movingPlatform) {
					movingPlatform.GetComponent<MovingPlatform> ().move = true;
				}
				powerLine.GetComponent<MeshRenderer> ().material = powerOn;
				buttonCooldown = 0;
				buttonTall = true;
			}
		}
	}
}
