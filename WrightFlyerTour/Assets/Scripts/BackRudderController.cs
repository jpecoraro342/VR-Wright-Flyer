using UnityEngine;
using System.Collections;

public class BackRudderController : MonoBehaviour {

	public float smooth = 2.0F;

	private CardboardHead head;
	private Vector3 initialOffset;
	private float initialObjPositionY;
	private float objOffsetBackRudder = 20F;

	// 0 degrees == 360 degrees... take that into account
	private float overflowDegree = 0F;

	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		initialOffset = head.transform.eulerAngles;

		// Backrudder initial measurements
		initialObjPositionY = transform.eulerAngles.y;
		if (initialObjPositionY - objOffsetBackRudder < 0) {
			overflowDegree = 360 + (initialObjPositionY - objOffsetBackRudder);
		}

	}

	void Update() {
		backRudderControl ();
	}

	void backRudderControl() {
		if (head.transform.eulerAngles.y > initialOffset.y + 2) {
			float speed = (float) ((head.transform.eulerAngles.y - (initialOffset.y + 2)) / 20); 
			if (transform.eulerAngles.y < initialObjPositionY + objOffsetBackRudder || transform.eulerAngles.y >= overflowDegree) {
				transform.Rotate (0, speed, 0);

			}

			// Object may get stuck after moving it, so check that it does not over rotate
			if ((transform.eulerAngles.y > initialObjPositionY + objOffsetBackRudder) && transform.eulerAngles.y < overflowDegree) {
				Quaternion target = Quaternion.Euler (0, initialObjPositionY + objOffsetBackRudder - 0.1F, 0);
				transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			}
		}
		else if (head.transform.eulerAngles.y < initialOffset.y - 2) {
			float speed = (float) ((head.transform.eulerAngles.y - (initialOffset.y - 2)) / 20); 
			if (transform.eulerAngles.y < initialObjPositionY + objOffsetBackRudder || transform.eulerAngles.y >= overflowDegree) {
				transform.Rotate (0, speed, 0);
			}

			if ((transform.eulerAngles.y > initialObjPositionY + objOffsetBackRudder) && transform.eulerAngles.y < overflowDegree) {
				Quaternion target = Quaternion.Euler (0, overflowDegree + 0.1F, 0);
				transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			}
		}
	}

}
