using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	private float zoom;
	private bool zoomIn;
	private bool zoomCollide;

	// Use this for initialization
	void Start () {
		zoomIn = false;
		zoomCollide = false;
		zoom = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast (transform.position, transform.forward, 2)) {
			zoomIn = true;
			Debug.Log ("hit surfae");
		} else {
			if (!Physics.Raycast (transform.position, -transform.forward, 1)) {
				if (zoomCollide == false) {
					zoomIn = false;
				}
			}
		}


		if (zoomIn == true) {
			if (zoom < 4) {
				transform.localPosition = transform.localPosition + new Vector3 (0, 0, 0.1f);
				zoom = zoom + 0.17f;
			}
		}


		if (zoomIn == false) {
			if (zoom > 0) {
				transform.localPosition = transform.localPosition + new Vector3 (0, 0, -0.1f);
				zoom = zoom - 0.17f;
				Debug.Log ("ZoomOut");
			}
		}

	}



	void OnTriggerStay() {
		zoomCollide = true;
	}

	void OnTriggerEnter () {
		zoomCollide = true;
	}
	void OnTriggerExit () {
		zoomCollide = false;
		Debug.Log ("TriggerExit");
	}

}
