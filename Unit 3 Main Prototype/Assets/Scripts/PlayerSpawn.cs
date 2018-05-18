using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	public GameObject player;
	public GameObject playerSpawner;

	//UNUSED//

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!player.active) {
			Instantiate (playerSpawner, transform.position, new Quaternion (0,0,0,0));
			Destroy (player);
		}
	}
	void onCollisionEnter(Collision hitPlayer) {
		player = hitPlayer.gameObject;
		player.tag = "player1";
		player.SetActive(true);
	}
}
