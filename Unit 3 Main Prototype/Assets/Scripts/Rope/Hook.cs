using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {

	public GameObject Origin;
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (Origin.transform.position);
		transform.up = transform.forward;
	}
}
