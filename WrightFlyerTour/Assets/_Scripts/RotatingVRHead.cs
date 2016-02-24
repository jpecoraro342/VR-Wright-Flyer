using UnityEngine;
using System.Collections;

public class RotatingVRHead : MonoBehaviour {

	public GameObject pitchArrow;
	public GameObject rollArrow;
	public GameObject yawArrow;

	public float maxRotation;
	public float speed;

	public Vector3 rotateVector;

	// Use this for initialization
	void Start () {
		rotateVector = Vector3.zero;
		StartCoroutine(testSequence());
	}
	
	// Update is called once per frame
	void Update () {
		var scale = new Vector3(speed*Time.deltaTime, speed*Time.deltaTime, speed*Time.deltaTime);

		//Check max rotation bounds
		var currentRotationAngles = eulerAnglesWithNegative(transform.rotation.eulerAngles);
		if (Vector3.Scale(rotateVector, currentRotationAngles).magnitude > maxRotation) {
			rotateVector = rotateVector*-1;
		}

		transform.Rotate(Vector3.Scale(rotateVector, scale));
	}

	void startPitchRotate() {
		stopRotate();
		pitchArrow.SetActive(true);
		rotateVector = new Vector3(0,0,1);
		Debug.Log("Pitch rotate started");
	}
		

	void startRollRotate() {
		stopRotate();
		rollArrow.SetActive(true);
		rotateVector = new Vector3(1,0,0);
		Debug.Log("Roll rotate started");
	}

	void startYawRotate() {
		stopRotate();
		yawArrow.SetActive(true);
		rotateVector = new Vector3(0,1,0);
		Debug.Log("Yaw rotate started");
	}

	void stopRotate() {
		pitchArrow.SetActive(false);
		rollArrow.SetActive(false);
		yawArrow.SetActive(false);
		gameObject.transform.rotation = Quaternion.identity;
		rotateVector = Vector3.zero;
	}

	Vector3 eulerAnglesWithNegative(Vector3 angles) {
		var x = getAdjustedAngle(angles.x);
		var y = getAdjustedAngle(angles.y);
		var z = getAdjustedAngle(angles.z);

		return new Vector3(x, y, z);
	}

	float getAdjustedAngle(float angle) {
		if (angle > 180) {
			return angle-360;
		}
		return angle;
	}

	IEnumerator testSequence() {
		startPitchRotate();

		yield return new WaitForSeconds(5);

		startRollRotate();

		yield return new WaitForSeconds(5);

		startYawRotate();

		yield return new WaitForSeconds(5);

		stopRotate();
	}
}
