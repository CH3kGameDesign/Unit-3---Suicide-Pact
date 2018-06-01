using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float hcamspeed = 2;         //Speed Rotating Horizontally
	public float vcamspeed = 2;         //Speed Rotating Vertically

	public bool notdead = true;         //Whether Alive Or Not

	//public so you can rotate player start rotation
	public float yaw = 0;
	public float pitch = 0;

    //Maximum pitch Rotations
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

        //Ensure Pitch doesn't exceed constraints
		if (pitch > pitchMax) {
			pitch = pitchMax;
		}
		if (pitch < pitchMin) {
			pitch = pitchMin;
		}

        //Actually Move Camera
		transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);
	}
}
