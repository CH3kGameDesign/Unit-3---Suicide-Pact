using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    /*
    WHAT SCRIPT DOES:
    -   Moves Player
    -   Jump
    -   Respawns Character
    */

    public float hcamspeed = 0.2f;                  //Speed To Rotate Character         MUST MATCH CAMERA ROTATE SPEED
	public float jumpForce = 10;                    //How Much Force is Applied When Jumping
	public float speed = 2;                         //Character Speed
	public float maxspeed = 2;                      //Character MaxSpeed
	public GameObject players;                      //Players Controller GameObject
	public GameObject cameraObject;                 //CharCorrection, used to make sure character moves relative to camera
	public GameObject playerModel;                  //Player Model
    

	public bool notdead = true;                     //Whether Player is Dead

	private float distanceOfRay = 0.2f;             //Raycheck distance for whether can jump

	public Rigidbody rb;                            //Rigidbody Reference

	public Vector3 respawn;                         //Respawn Location                  Set at Start in CharacterSelect
	public Quaternion respawnRotation;              //Respawn Rotation                  Set at Start in CharacterSelect

	private bool isGrounded;                        //Whether touching Ground or not

	// Use this for initialization
	void Start () {
        //Set Variables
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
        //Movement

        ///////////////////////////////////
        if (notdead)
        {
            //Movement Relative To Camera
            Vector3 moveX = cameraObject.transform.right * Input.GetAxis("Horizontal") * speed;
            Vector3 moveZ = cameraObject.transform.forward * Input.GetAxis("Vertical") * speed;

            Vector3 movement = moveX + moveZ;

            rb.MovePosition(transform.position + movement);

            //Different Movement Attempts

            //////////////////////////////////////////
            //Attempt to fix Wall Stick problem
            //Vector3 hMove = rb.velocity;
            //hMove.y = 0;
            //Calculate Approx. Distance
            //float distance = hMove.magnitude * Time.fixedDeltaTime;
            //Normalize
            //hMove.Normalize();
            //RaycastHit hit;

            //Collision Check
            //if (rb.SweepTest (hMove, out hit, distance)) {
            //Stop Movement
            //rb.velocity = new Vector3(0, rb.velocity.y, 0);
            //}
            ////////////////////////////////////////////


            //transform.position += movement;



            ///////////////////////////////////
            //Vector3 moveX = transform.right * Input.GetAxis ("Horizontal") * speed;
            //Vector3 moveY = transform.up * rb.velocity.y;
            //Vector3 moveZ = transform.forward * Input.GetAxis ("Vertical") * speed;

            //Vector3 movement = moveX + moveY + moveZ;

            //rb.velocity = movement;
            ///////////////////////////////////

            //if (rb.velocity.x < maxspeed && rb.velocity.z < maxspeed) {

            //if (Input.GetKey (KeyCode.W)) {
            //transform.position += (transform.forward * 0.1f);
            //}
            //if (Input.GetKey (KeyCode.S)) {
            //transform.position += (transform.forward * -0.1f);
            //}
            //if (Input.GetKey (KeyCode.A)) {
            //	transform.position += (transform.right * -0.1f);
            //}
            //if (Input.GetKey (KeyCode.D)) {
            //rb.velocity = (transform.right * speed);
            //rb.AddForce (transform.right * speed, ForceMode.Impulse);
            //transform.position += (transform.right * 0.1f);
            //}
            //}
            //////////////////////////////////

            //Raycast If Grounded
            if (Physics.Raycast((transform.position + new Vector3(0.35f, -0.9f, 0.35f)), -transform.up, distanceOfRay))
            {
                isGrounded = true;
            }
            else if (Physics.Raycast((transform.position + new Vector3(-0.35f, -0.9f, 0.35f)), -transform.up, distanceOfRay))
            {
                isGrounded = true;
            }
            else if (Physics.Raycast((transform.position + new Vector3(-0.35f, -0.9f, -0.35f)), -transform.up, distanceOfRay))
            {
                isGrounded = true;
            }
            else if (Physics.Raycast((transform.position + new Vector3(0.35f, -0.9f, -0.35f)), -transform.up, distanceOfRay))
            {
                isGrounded = true;
            }
            else if (Physics.Raycast((transform.position + new Vector3(0, -0.9f, 0)), -transform.up, distanceOfRay))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }

            //Raycast Lines
            Debug.DrawLine(transform.position + new Vector3(0, -0.9f, 0), transform.position + new Vector3(0, -1.1f, 0));
            Debug.DrawLine(transform.position + new Vector3(0.35f, -0.9f, 0.35f), transform.position + new Vector3(0.35f, -1.1f, 0.35f));
            Debug.DrawLine(transform.position + new Vector3(-0.35f, -0.9f, 0.35f), transform.position + new Vector3(-0.35f, -1.1f, 0.35f));
            Debug.DrawLine(transform.position + new Vector3(-0.35f, -0.9f, -0.35f), transform.position + new Vector3(-0.35f, -1.1f, -0.35f));
            Debug.DrawLine(transform.position + new Vector3(0.35f, -0.9f, -0.35f), transform.position + new Vector3(0.35f, -1.1f, -0.35f));

            //Jump
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, jumpForce, gameObject.GetComponent<Rigidbody>().velocity.z);
            }
            if (Input.GetKey(KeyCode.JoystickButton0) && isGrounded)
            {
                gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, jumpForce, gameObject.GetComponent<Rigidbody>().velocity.z);
            }
        }
	
	}

	void Update () {
		//Respawn Input
		if (Input.GetKeyDown (KeyCode.R)) {
			RespawnAction ();
		}
		if (Input.GetKeyDown (KeyCode.JoystickButton3)) {
			RespawnAction ();
		}
	}


    //Respawn
	void RespawnAction () {
		transform.position = respawn;
		transform.rotation = respawnRotation;
		notdead = true;

        GetComponent<Rigidbody> ().velocity = Vector3.zero;
        //Change Hats on Respawn
        //GetComponentInParent<DressUpParty> ().HatReset ();
        //Reset Live Colour
        GetComponentInParent<DressUpParty>().HatColourReset();


        //Disable Ragdoll-esque motion
        playerModel.transform.eulerAngles = Vector3.zero;
		transform.eulerAngles = Vector3.zero;
		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}
}
