using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Move Moving Platform
    */

    public Animator anim;       //Get Animator Component
	public bool move;           //Whether To Move

	// Initialization
	void Start () {
		anim = GetComponent<Animator> ();
		move = false;
	}
	
	// Activate Animation if asked to move
	void Update () {
		if (move) {
			anim.Play ("MovingPlatform1Moving");
			move = false;
		}
	}
}
