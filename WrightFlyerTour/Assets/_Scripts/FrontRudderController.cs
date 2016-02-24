using UnityEngine;
using System.Collections;

public class FrontRudderController : MonoBehaviour {

	public float smooth = 4.0F;
	public GameObject lever;
	public GameObject axisPulley;

	private CardboardHead head;
	private Vector3 initialOffset;
	private float initialObjPositionX;
	private float objOffsetFrontRud = 20F;
    private bool botRot = false;
    private bool topRot = false;

	// 0 degrees == 360 degrees... take that into account
	private float overflowDegree = 0F;

	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		//initialOffset = head.transform.localEulerAngles;
		initialObjPositionX = transform.localEulerAngles.x;
		//print("Wing: " + initialOffset.x + " " + initialOffset.y + " " + initialOffset.x);
		initialOffset = new Vector3(0, 180, 0);

	}

	void FixedUpdate() {
		frontRudderControl ();
	}

    void frontRudderControl() {

		float paddingDegree = 2F;  // This is how much they can "tilt" before it starts to react
		// When we look down
		if (head.transform.localEulerAngles.x >= initialOffset.x + paddingDegree && head.transform.localEulerAngles.x <= 180 && !botRot) {
			float speed = (float) ((head.transform.localEulerAngles.x - (initialOffset.x + paddingDegree)) / 20);
			//speed = Mathf.Min (0.1F, speed);
            /*
			if ((transform.localEulerAngles.x <= initialObjPositionX + objOffsetFrontRud || transform.localEulerAngles.x >= 360 - objOffsetFrontRud)) {
				transform.Rotate (0, 0, -speed);
			}
            */

			// Object may get stuck after moving it, so check that it does not over rotate
			// Front rudder rotates from 360 to 340
			if ((transform.localEulerAngles.x <= 360 - objOffsetFrontRud) && transform.localEulerAngles.x >= 180) {
				//print("hey");
				//Quaternion target = Quaternion.Euler (345, 0, 0);
				//transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                botRot = true;
            }
            else if ((transform.localEulerAngles.x <= initialObjPositionX + objOffsetFrontRud + 10 || transform.localEulerAngles.x >= 360 - objOffsetFrontRud))
            {
                transform.Rotate(-speed, 0, 0);
                lever.transform.Rotate(-speed, 0, 0);
                axisPulley.transform.Rotate(-speed, 0, 0);
                topRot = false;
            }
        }

		// Looking Up
		else if (head.transform.localEulerAngles.x <= 360 - paddingDegree && head.transform.localEulerAngles.x >= 180 && !topRot) {
			float speed = (float) ((head.transform.localEulerAngles.x - (360 - paddingDegree)) / 20); 
			//speed = Mathf.Max (-0.1F, speed);
            /*
			if (transform.localEulerAngles.x >= 360 - objOffsetFrontRud || transform.localEulerAngles.x <= initialObjPositionX + objOffsetFrontRud && transform.localEulerAngles.x >= initialObjPositionX + objOffsetFrontRud)
            {
				transform.Rotate (0, 0, -speed);
			}
            */
			if ((transform.localEulerAngles.x >= initialObjPositionX + objOffsetFrontRud) && transform.localEulerAngles.x <= 180) {
				//Quaternion target = Quaternion.Euler (objOffsetFrontRud, 0, 0);
				//transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                topRot = true;
			}
            else if (transform.localEulerAngles.x >= 360 - objOffsetFrontRud+ - 10 || transform.localEulerAngles.x <= initialObjPositionX + objOffsetFrontRud)
            {
                transform.Rotate(-speed, 0, 0);
                lever.transform.Rotate(-speed, 0, 0);
                axisPulley.transform.Rotate(-speed, 0, 0);
                botRot = false;
            }
        }
	}
}
