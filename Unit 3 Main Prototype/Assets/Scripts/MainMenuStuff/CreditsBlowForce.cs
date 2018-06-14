using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBlowForce : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Launches The Players In Credits
    */

    //Launch Players
    private void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20, 20), 200, Random.Range(-20, 20)));
    }
}
