using UnityEngine;
using System.Collections;

public class WingWarpController : MonoBehaviour {

	public float smooth = 4.0F;

	private CardboardHead head;
	private Vector3 initialOffset;
	private float initialObjPositionZ;
	private float objOffsetWingWarp = 3F;

	// 0 degrees == 360 degrees... take that into account
	private float overflowDegree = 0F;

	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		initialOffset = head.transform.eulerAngles;
		initialObjPositionZ = transform.eulerAngles.z;

	}

	void Update() {
		wingWarpControl ();
	}

	void wingWarpControl() {
		// Z rotation is different, starts at 0 instead of 180 (like Y) so we restrict its range

		float paddingDegree = 2F;  // This is how much they can "tilt" before it starts to react
		// Tilting CW
		if (head.transform.eulerAngles.z > initialOffset.z + paddingDegree && head.transform.eulerAngles.z < 180) {
			float speed = (float) ((head.transform.eulerAngles.z - (initialOffset.z + paddingDegree)) / 40); 
			speed = Mathf.Min (0.17F, speed);
			if (transform.eulerAngles.z < initialObjPositionZ + objOffsetWingWarp || transform.eulerAngles.z > 360 - objOffsetWingWarp) {
				transform.Rotate (0, 0, -speed);
			}

			// Object may get stuck after moving it, so check that it does not over rotate
			if ((transform.eulerAngles.z < 360 - objOffsetWingWarp) && transform.eulerAngles.z > 180) {
				
				Quaternion target = Quaternion.Euler (0, 0, 360);
				transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			}
		}

		// Tilting CCW
		else if (head.transform.eulerAngles.z < 360 - paddingDegree && head.transform.eulerAngles.z > 180) {
			float speed = (float) ((head.transform.eulerAngles.z - (360 - paddingDegree)) / 40); 
			speed = Mathf.Max (-0.17F, speed);
			if (transform.eulerAngles.z > 360 - objOffsetWingWarp || transform.eulerAngles.z < initialObjPositionZ + objOffsetWingWarp) {
				transform.Rotate (0, 0, -speed);
			}

			if ((transform.eulerAngles.z > initialObjPositionZ + objOffsetWingWarp) && transform.eulerAngles.z < 180) {
				Quaternion target = Quaternion.Euler (0, 0, 360 - objOffsetWingWarp + 0.01F);
				transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			}
		}
	}
}
