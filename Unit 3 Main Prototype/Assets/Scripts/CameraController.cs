using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float hcamspeed = 2;
	public float vcamspeed = 2;

	public bool notdead = true;

	private float yaw = 0;
	private float pitch = 0;


	// Use this for initialization
	void Start () {
		//Set Cursor to be locked to window
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}


	// Update is called once per frame
	void Update () {
			//Camera Movement
			yaw += hcamspeed * Input.GetAxis ("Mouse X");
			pitch -= vcamspeed * Input.GetAxis ("Mouse Y");
			transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);
	}
}
