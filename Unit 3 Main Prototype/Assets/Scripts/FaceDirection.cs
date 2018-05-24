using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour {

	public GameObject Camera;

	private float camY;

	void Update () {
		if (GetComponentInParent<Movement> ().notdead) {
			transform.rotation = Camera.transform.rotation;
			camY = transform.rotation.y;
			transform.rotation = new Quaternion (0, Camera.transform.rotation.w, 0, -Camera.transform.rotation.y);
		}
	}
}
