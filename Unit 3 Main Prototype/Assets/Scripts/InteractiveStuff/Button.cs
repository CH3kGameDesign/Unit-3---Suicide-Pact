using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

	public GameObject door;                         //The door it activates
	public List <GameObject> doors;				    //Multiple doors opening one after the other
	public bool multipleDoors = false;				//Tick if using multiple doors

	public GameObject launchPad;                    //The launchpad it activates
    public GameObject movingPlatform;               //The movingplatform it activates
    public GameObject powerLine;                    //The powerline that links the button to the buttonee
	public Material powerOff;                       //PowerOff Material for powerline
	public Material powerOn;                        //PowerOn Material for powerline

	public float buttonCooldownLimit = 20;			//Time before buttonCoolDown does something
	private float buttonCooldown;					//Legit just for counting how long powerline should light for tall button press
	private bool buttonTall;						//Whether button is tall
	private int doorNumber = 0;					    //Which door to turn on/off

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
					//Use Multiple Doors
					if (multipleDoors)
					{
						MultipleDoors ();
					}
                    //PowerLine On
                    powerLine.GetComponent<MeshRenderer>().material = powerOn;
                    buttonCooldown = 0;
                    buttonTall = true;
                }
            }
		}
	}

    //Open/Close Multiple Doors

    void MultipleDoors()
    {
        doorNumber = 0;
        doors[doorNumber].SetActive(false);
        Invoke ("MultipleDoors2", 0.6f);
    }
    void MultipleDoors2()
    {
        doors[doorNumber].SetActive(true);
        doorNumber = 1;
        doors[doorNumber].SetActive(false);
        if (doors.Count > 2)
            Invoke("MultipleDoors3", 0.6f);
        else Invoke("MultipleDoorsClose", 0.6f);
    }
    void MultipleDoors3()
    {
        doors[doorNumber].SetActive(true);
        doorNumber = 2;
        doors[doorNumber].SetActive(false);
        if (doors.Count > 3)
            Invoke("MultipleDoors4", 0.6f);
        else Invoke("MultipleDoorsClose", 0.6f);
    }
    void MultipleDoors4()
    {
        doors[doorNumber].SetActive(true);
        doorNumber = 3;
        doors[doorNumber].SetActive(false);
        Invoke("MultipleDoorsClose", 0.6f);
    }
    void MultipleDoorsClose()
    {
        doors[doorNumber].SetActive(true);
    }

    /*
    void MultipleDoors2() {
		doors [doorNumber].SetActive(true);
		doorNumber++;
		if (doorNumber <= doors.Count) {
            Debug.Log(doorNumber);
            doors [doorNumber].SetActive(false);
			Invoke ("MultipleDoors2", 1);
		} 
	}
    */
}
