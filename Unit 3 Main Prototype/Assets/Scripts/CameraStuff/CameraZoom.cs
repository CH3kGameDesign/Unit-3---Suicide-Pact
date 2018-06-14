using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Zoom Camera In/Out
    */

    private float zoom;                 //How Much Zoomed In
    private bool zoomIn;                //Whether To Zoom
	private bool zoomCollide;           //Whether Zooming Out Will Hit Objects

	// Initialization
	void Start () {
		zoomIn = false;
		zoomCollide = false;
		zoom = 0;
	}
	
	// Zoom
	void Update () {
		
        //Zoom In If Something In Front
		if (Physics.Raycast (transform.position, transform.forward, 2)) {
			zoomIn = true;
			Debug.Log ("hit surfae");
		}
        //Zoom Out If Nothing In Front
        else {
			if (!Physics.Raycast (transform.position, -transform.forward, 1)) {
				if (zoomCollide == false) {
					zoomIn = false;
				}
			}
		}
		/*
		if (zoomCollide == true) {
			zoomIn = true;
			Debug.Log ("hit surfae");
		} else {
			zoomIn = false;
		}
		*/

        //Actually Zooming
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


    //Collision With Camera, To Stop Zooming Out Into Wall
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
