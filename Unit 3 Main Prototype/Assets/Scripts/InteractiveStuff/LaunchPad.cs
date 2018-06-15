using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Yeet the Player
    */

    public Animator anim;           //Animator Component of LaunchPad
	public bool launch;             //Launch (Controlled By Button Script)
	public float strengthup;        //Launch Force Up
	public float strengthfor;       //Launch Force Out

	private bool launchable;        //Whether Player Is On LaunchPad


	// Update is called once per frame
	void Update () {
		if (launch) {
			anim.Play ("LaunchPadLaunch");
			if (!launchable) {
				launch = false;
			}
		}
	}

    //LAAUUAUUUANCH THE PLAYER if player is there
	void OnTriggerStay(Collider col) {
		if (launch) {
			col.GetComponentInParent<Rigidbody> ().AddForce ((transform.up) * strengthup, ForceMode.Impulse);
			col.GetComponentInParent<Rigidbody> ().AddForce ((-transform.right) * strengthfor, ForceMode.Impulse);

			Debug.Log ("LUAUAUNCH");
			launch = false;
		}
		launchable = true;
	}

    //Don't Launch Anything if not there on Launch
	void OnTriggerExit() {
		launchable = false;
	}


}
