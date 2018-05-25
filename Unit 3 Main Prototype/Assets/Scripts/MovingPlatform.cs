using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

	public Animator anim;
	public bool move;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		move = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (move) {
			anim.Play ("MovingPlatform1Moving");
			move = false;
		}
	}
}
