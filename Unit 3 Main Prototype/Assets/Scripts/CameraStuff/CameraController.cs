using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float hcamspeed = 2;
	public float vcamspeed = 2;

	public bool notdead = true;

	//public so you can rotate player start rotation
	public float yaw = 0;
	public float pitch = 0;

	private float pitchMax = 60;
	private float pitchMin = -120;

	void Start () {
		//Set Cursor to be locked to window
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}


	void Update () {
		//Camera Movement
		yaw += hcamspeed * Input.GetAxis ("Mouse X");
		pitch -= vcamspeed * Input.GetAxis ("Mouse Y");

		if (pitch > pitchMax) {
			pitch = pitchMax;
		}
		if (pitch < pitchMin) {
			pitch = pitchMin;
		}
		transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);
	}
}
