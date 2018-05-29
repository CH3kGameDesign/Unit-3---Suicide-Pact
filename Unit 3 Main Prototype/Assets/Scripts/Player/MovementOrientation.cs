using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOrientation : MonoBehaviour {

	public float hcamspeed = 2;

	public bool notdead = true;

	private float yaw = 0;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		yaw += hcamspeed * Input.GetAxis ("Mouse X");
		transform.eulerAngles = new Vector3 (0.0f, yaw, 0.0f);
	}
}
