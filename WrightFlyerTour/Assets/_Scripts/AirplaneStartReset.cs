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
		StartCoroutine(resetRigidBody(plane));
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
		FrontRudderController script = GameComponent<FrontRudderController>();
		script.enabled = true;
	}

	public void enableYawMovement() {
		BackRudderController script = GameComponent<BackRudderController>();
		script.enabled = true;
	}

	public void enableRollMovement() {
		WingWarpController script = GameComponent<WingWarpController>();
		script.enabled = true;
	}

	public void disablePitchMovement() {
		FrontRudderController script = GameComponent<FrontRudderController>();
		script.enabled = false;
	}

	public void disableYawMovement() {
		BackRudderController script = GameComponent<BackRudderController>();
		script.enabled = false;	
	}

	public void disableRollMovement() {
		WingWarpController script = GameComponent<WingWarpController>();
		script.enabled = false;
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