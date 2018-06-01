using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public GameObject door;                         //The door it activates
	public GameObject launchPad;                    //The launchpad it activates
    public GameObject movingPlatform;               //The movingplatform it activates
    public GameObject powerLine;                    //The powerline that links the button to the buttonee
	public Material powerOff;                       //PowerOff Material for powerline
	public Material powerOn;                        //PowerOn Material for powerline

	public float buttonCooldownLimit = 20;			//Time before buttonCoolDown does something
	private float buttonCooldown;					//Legit just for counting how long powerline should light for tall button press
	private bool buttonTall;						//Whether button is tall

	// Use this for initialization
	void Start () {
        //Set Start Variables
		buttonTall = false;
		buttonCooldown = 0;
	}

	void FixedUpdate () {
        //How long powerline should stay on for tall buttons
		if (buttonTall == true) {
			buttonCooldown++;
			if (buttonCooldown > buttonCooldownLimit) {
				powerLine.GetComponent<MeshRenderer>().material = powerOff;
			}
		}
	}

	void OnCollisionEnter() {
        //Activate LaunchPad
		if (launchPad) {
			launchPad.GetComponent<LaunchPad> ().launch = true;
		}
        //Activate MovingPlatform
		if (movingPlatform) {
			movingPlatform.GetComponent<MovingPlatform> ().move = true;
		}
	}

	void OnCollisionStay() {
        //Keep Door Open
		if (door) {
			door.SetActive (false);
		}
        //Keep PowerLine On
		powerLine.GetComponent<MeshRenderer>().material = powerOn;
	}

	void OnCollisionExit() {
        //Close Door
		if (door) {
			door.SetActive (true);
		}
        //Turn PowerLine Off
		powerLine.GetComponent<MeshRenderer>().material = powerOff;
	}

    //Tall Button Stuff
	void OnTriggerStay(Collider obj) {
        //Make Sure Player is Active
		if (obj.GetComponentInParent<Movement> ().enabled == true) {
            //Make Sure Player is Alive
            if (obj.GetComponentInParent<Movement>().notdead == true)
            {
                if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton2))
                {
                    //Use LaunchPad
                    if (launchPad)
                    {
                        launchPad.GetComponent<LaunchPad>().launch = true;
                    }
                    //Use MovingPlatform
                    if (movingPlatform)
                    {
                        movingPlatform.GetComponent<MovingPlatform>().move = true;
                    }
                    //PowerLine On
                    powerLine.GetComponent<MeshRenderer>().material = powerOn;
                    buttonCooldown = 0;
                    buttonTall = true;
                }
            }
		}
	}
}
