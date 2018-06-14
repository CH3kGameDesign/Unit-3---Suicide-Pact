using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{

    /*
    WHAT SCRIPT DOES:
    -   Easter Egg Found/Not Found
    */

    public bool found = false;                  //Is Easter Egg Found

    //On Player Touch Easter Egg, Found = true
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Movable")
        {
            found = true;
        }
    }
}