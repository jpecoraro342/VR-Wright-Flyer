using UnityEngine;
using System.Collections;

public class AirplaneStartReset : MonoBehaviour {

	public GameObject planeLaunchingPoint;
	public GameObject plane;

	public GameObject planeCamera;

	// TODO: Get all the objects

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void resetAirplane() {
		StartCoroutine(resetRigidBody());
		startPlaneSequence();
	}

	void startPlaneSequence() {
		// TODO: 
		// Freeze Rotation of Plane? 
	}
		
	public void enablePlaneMovement() {
		// Turn gravity on
		// unfreeze some parts of rigidbody?
		// enable plane movement script
	}

	void disablePlaneMovement() {
		// Turn off gravity
		// Freeze Rigid Body
		// disable plane movement script
	}

	public void enablePitchMovement() {
		// turn on pitch script
	}

	public void enableYawMovement() {
		// turn on rudder script
	}

	public void enableRollMovement() {
		// turn on roll script
	}

	public void disablePitchMovement() {
		// turn on pitch script
	}

	public void disableYawMovement() {
		// turn on rudder script
	}

	public void disableRollMovement() {
		// turn on roll script
	}

	public void turnEngineOn() {

	}

	public void turnEngineOff() {

	}

	IEnumerator resetRigidBody(GameObject gobject) {
		gobject.transform.localPosition = Vector3.zero;

		var rigidbody = gobject.GetComponent<Rigidbody>();

		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;

		rigidbody.Sleep();

		yield return new WaitForSeconds(1.0f);

		rigidbody.WakeUp();
	}
}