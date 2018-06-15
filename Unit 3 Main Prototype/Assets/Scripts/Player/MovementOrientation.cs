using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOrientation : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Ensures Forward Means Forward In Terms Of Movement
    */

    public float hcamspeed = 2;         //Horizontal Camera Speed

	public bool notdead = true;         //Dead Or No

	private float yaw = 0;              //Y Axis Rotation


	// Rotate
	void Update () {
		yaw += hcamspeed * Input.GetAxis ("Mouse X");
		transform.eulerAngles = new Vector3 (0.0f, yaw, 0.0f);
	}
}
