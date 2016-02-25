using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Aeroplane;

public class AirplaneStartReset : MonoBehaviour {

	public GameObject planeLaunchingPoint;
	public GameObject plane;
	public GameObject planeCamera;
	public GameObject charCamera;
	public PropellerRotate p1;
	public PropellerRotate p2;
	public FrontRudderController frontRudScript;
	public BackRudderController backRudScript;
	public WingWarpController wingWarpScript;
	public CustomAirplaneUserControl planeScript;
	public AeroplaneController planeController;





/* //TEST CODE
	public bool frontRudOn = false;
	public bool backRudOn = false;
	public bool wingWarpOn = false;


	if (frontRudOn) {
			enablePitchMovement();
		}
		else {
			disablePitchMovement();
		}

		if (backRudOn) {
			enableYawMovement();
		}
		else {
			disableYawMovement();
		}

		if (wingWarpOn) {
			enableRollMovement();
		}
		else {
			disableRollMovement();
		}

*/

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
		plane.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
	}

	public void enablePlaneCamera() {
		planeCamera.SetActive(true);
	}

	public void disablePlaneCamera() {
		planeCamera.SetActive(false);
	}

	public void enableCharCamera() {
		charCamera.SetActive(true);
	}

	public void disableCharCamera() {
		charCamera.SetActive(false);
	}
		
	public void enablePlaneMovement() {
		// Turn gravity on
		// unfreeze some parts of rigidbody?
		// enable plane movement script

		plane.GetComponent<Rigidbody>().useGravity = true;
		plane.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
		// planeScript.enabled = true;
		StartCoroutine(reduceTheLift());
	}

	void disablePlaneMovement() {
		// Turn off gravity
		// Freeze Rigid Body
		// disable plane movement script

		plane.GetComponent<Rigidbody>().useGravity = false;
		plane.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		// planeScript.enabled = false;
	}

	public void enablePitchMovement() {
		frontRudScript.enabled = true;
	}

	public void enableYawMovement() {
		backRudScript.enabled = true;
	}

	public void enableRollMovement() {
		wingWarpScript.enabled = true;
	}

	public void disablePitchMovement() {
		frontRudScript.enabled = false;
	}

	public void disableYawMovement() {
		backRudScript.enabled = false;	
	}

	public void disableRollMovement() {
		wingWarpScript.enabled = false;
	}

	public void turnEngineOn() {
		//planeScript.enabled = true;
		p1.enabled = true;
		p2.enabled = true;
		planeScript.enabled = true;
	}

	public void turnEngineOff() {
		p1.enabled = false;
		p2.enabled = false;
		planeScript.enabled = false;
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

	IEnumerator reduceTheLift() {
		while (planeController.getLift() > 0) {
			yield return new WaitForSeconds(6);
			planeController.setLift(planeController.getLift() - .1f);
		}
	}
}