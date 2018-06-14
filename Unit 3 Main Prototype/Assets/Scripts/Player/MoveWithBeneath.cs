using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithBeneath : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Moves Character With Floor Beneath
    */

    private Vector3 position;                   //Floor Present Position
    private Vector3 pastPosition;               //Floor Past Position
    private Vector3 distancePosition;           //Distance Between Past and Present Positions

    // Initialization
    void Start () {
        //Set Variables to null
        position = Vector3.zero;
        pastPosition = Vector3.zero;
        distancePosition = Vector3.zero;
    }
	
	//Move with Ground Beneath
	void Update () {
        RaycastHit hit;
        //Check what ground is beneath you
        if (Physics.Raycast((transform.position + new Vector3(0, -0.9f, 0)), -transform.up, out hit, 0.2f))
        {
            //Check If Ground Moves
            if (hit.collider.tag == "Movable")
            {
                //Move With Ground
                position = hit.collider.transform.position;
                if (pastPosition != Vector3.zero)
                {
                    distancePosition = position - pastPosition;
                    transform.position += distancePosition;

                }
                pastPosition = hit.collider.transform.position;
            }
        }
        else
        {
            //Set Variables to null
            position = Vector3.zero;
            pastPosition = Vector3.zero;
            distancePosition = Vector3.zero;
        }
    }
}
