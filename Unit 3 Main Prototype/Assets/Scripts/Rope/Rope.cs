using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {
	
    //Objects that will interact with the rope
    public Transform whatTheRopeIsConnectedTo;
    public Transform whatIsHangingFromTheRope;

    //Line renderer used to display the rope
    private LineRenderer lineRenderer;

    //A list with all rope sections
    public List<Vector3> allRopeSections = new List<Vector3>();

    //Rope data
    public float ropeLength = 1f;

    //Mass of what the rope is carrying
    public float loadMass = 0.1f;

    //The joint used to approximate the rope
    SpringJoint springJoint;

    void Start() 
	{
        springJoint = whatTheRopeIsConnectedTo.GetComponent<SpringJoint>();

        //Get LineRenderer
        lineRenderer = GetComponent<LineRenderer>();

		//Update/Initialize Spring Calculation (Should only have to do this once)
        UpdateSpring();

        //Add the weight to what the rope is carrying
        whatIsHangingFromTheRope.GetComponent<Rigidbody>().mass = loadMass;
    }
	
	void Update() 
	{
        //Display the rope with a line renderer
        DisplayRope();
    }

    //Update the spring constant and the length of the spring
    private void UpdateSpring()
    {
        //
        //The mass of the rope
        //
        //Density of the wire
        float density = 7750f;
        //The radius of the wire
        float radius = 0.02f;

        float volume = Mathf.PI * radius * radius * ropeLength;

        float ropeMass = volume * density;

        //Add what the rope is carrying
        ropeMass += loadMass;


        //
        //The spring constant
        //
        //The force from the rope F = rope_mass * gravity, which is how much the top rope segment will carry
        float ropeForce = ropeMass * 9.81f;

        //Use the spring equation to calculate F = k * x should balance this force, 
        //where x is how much the top rope segment should stretch, such as 0.01m

        //Is about 146000
        float kRope = ropeForce / 0.01f;

        //print(ropeMass);

        //Add the value to the spring
        springJoint.spring = kRope * 1.0f;
        springJoint.damper = kRope * 0.8f;

        //Update length of the rope
        springJoint.maxDistance = ropeLength;
    }

    //Display the rope with a line renderer
    private void DisplayRope()
    {
        //This is not the physics width, but the visual width
        float ropeWidth = 0.2f;

        lineRenderer.startWidth = ropeWidth;
        lineRenderer.endWidth = ropeWidth;


        //Update the list with rope sections by approximating the rope with a bezier curve
        Vector3 A = whatTheRopeIsConnectedTo.position;
        Vector3 D = whatIsHangingFromTheRope.position;

        //Upper control point
        Vector3 B = A + whatTheRopeIsConnectedTo.up * (-(A - D).magnitude * 0.1f);

        //Lower control point
        Vector3 C = D + whatIsHangingFromTheRope.up * ((A - D).magnitude * 0.5f);

        //Get the positions
        BezierCurve.GetBezierCurve(A, B, C, D, allRopeSections);


        //An array with all rope section positions
        Vector3[] positions = new Vector3[allRopeSections.Count];

        for (int i = 0; i < allRopeSections.Count; i++)
        {
            positions[i] = allRopeSections[i];
        }

        //Add the positions to the line renderer
        lineRenderer.positionCount = positions.Length;

        lineRenderer.SetPositions(positions);
    }
}
