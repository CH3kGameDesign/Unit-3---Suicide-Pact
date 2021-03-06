﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceDirection : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Ensure Model Faces Forward In Terms Of Camera
    -   Crash Bandicoot Shadow
    */

    public GameObject Camera;       //Camera
    public GameObject shadow;       //Crash Bandicoot Shadow

    void Update () {
        //Face Out Camera Direction
		if (GetComponentInParent<Movement> ().notdead) {
			transform.rotation = new Quaternion (0, Camera.transform.rotation.w, 0, -Camera.transform.rotation.y);
		}

        RaycastHit hit;

        //Shadows
        if (GetComponentInParent<Movement>().enabled == true)
        {
            if (GetComponentInParent<Movement>().notdead == true)
            {
                if (Physics.Raycast((transform.position + new Vector3(0, -0.01f, 0)), -transform.up, out hit, 100))
                {
                    shadow.SetActive(true);
                    shadow.transform.position = new Vector3(transform.position.x, transform.position.y - hit.distance, transform.position.z);
                }
                else
                {
                    shadow.SetActive(false);
                }
            }
        }
        else
        {
            shadow.SetActive(false);
        }
	}
}
