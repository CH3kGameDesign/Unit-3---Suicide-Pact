using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Create PlayerModels On Start
    -   Returns To Menu On Button Press
    */

    public List<GameObject> playerModels;       //Player Models

    //Create Models
    private void Start()
    {
        for (int i = 0; i < playerModels.Count; i++)
        {
            Instantiate(playerModels[i], new Vector3(0, 10 + (2 * i), 0), Quaternion.Euler(0, 0, 0));
        }
    }

    // Return to Main Menu On Any Key Press
    void Update () {
		if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(0);
        }
	}
}
