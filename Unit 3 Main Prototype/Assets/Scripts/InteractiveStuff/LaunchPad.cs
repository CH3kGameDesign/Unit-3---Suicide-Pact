using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour {

	public Animator anim;
	public bool launch;
	public float strengthup;
	public float strengthfor;

	private bool launchable;

	// Use this for initialization
	void Start () {
		//anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (launch) {
			anim.Play ("LaunchPadLaunch");
			if (!launchable) {
				launch = false;
			}
		}
	}


	void OnTriggerStay(Collider col) {
		if (launch) {
			col.GetComponentInParent<Rigidbody> ().AddForce ((transform.up) * strengthup, ForceMode.Impulse);
			col.GetComponentInParent<Rigidbody> ().AddForce ((-transform.right) * strengthfor, ForceMode.Impulse);

			Debug.Log ("LUAUAUNCH");
			launch = false;
		}
		launchable = true;
	}

	void OnTriggerExit() {
		launchable = false;
	}


}
