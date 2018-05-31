using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

	public GameObject Origin;

	//Just used to slow down hook
	private float velX;
	private float velY;
	private float velZ;
	private bool notAttached = true;


	void Update () {
		//Rotate Hook
		transform.LookAt (Origin.transform.position);
		transform.up = transform.forward;

		//Slow down Hook
		if (notAttached == true) {
			if (GetComponent<Rigidbody> ().velocity.x > 0.1f) {
				velX = -0.02f;
			} else {
				velX = 0f;
			}
			if (GetComponent<Rigidbody> ().velocity.y > 0.1f) {
				velY = -0.02f;
			} else {
				velY = 0f;
			}
			if (GetComponent<Rigidbody> ().velocity.z > 0.1f) {
				velZ = -0.02f;
			} else {
				velZ = 0f;
			}
			GetComponent<Rigidbody> ().velocity += new Vector3 (velX, velY, velZ);

		}
	}

	//Whether Somehow is Attached to the Hook
	void OnTriggerEnter () {
		notAttached = false;
	}
	void OnTriggerStay () {
		notAttached = false;
	}
	void OnTriggerExit () {
		notAttached = true;
	}
}
