using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour {

	public Animator anim;
	public bool launch;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (launch) {
			anim.GetComponent<Animation>().Play ("LaunchPadLaunch");
		}
	}
}
