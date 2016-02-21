using UnityEngine;
using System.Collections;

public class BackRudderController : MonoBehaviour {

	public float smooth = 2.0F;

	private CardboardHead head;
	private Vector3 initialOffset;
	private float initialObjPositionY;
	private float objOffsetBackRudder = 20F;

    // Keep track of whether or not it has been overotated. Prevents jitter
    private bool leftRot = false;
    private bool rightRot = false;

    // 0 degrees == 360 degrees... take that into account
    private float overflowDegree = 0F;

	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		initialOffset = head.transform.eulerAngles;

		// Backrudder initial measurements
		initialObjPositionY = transform.eulerAngles.y;
		if (initialObjPositionY - objOffsetBackRudder < 0) {
			overflowDegree = 360 + (initialObjPositionY - objOffsetBackRudder);		// 360 + (0 - 20) = 340
		}

	}

	void FixedUpdate() {
		backRudderControl ();
	}

	void backRudderControl() {
		if (head.transform.eulerAngles.y > initialOffset.y + 2 && !leftRot) {
			float speed = (float) ((head.transform.eulerAngles.y - (initialOffset.y + 2)) / 20);

			// Object may get stuck after moving it, so check that it does not over rotate
			if ((transform.eulerAngles.y > initialObjPositionY + objOffsetBackRudder) && transform.eulerAngles.y < overflowDegree && transform.eulerAngles.y < 180) {
				Quaternion target = Quaternion.Euler (0, initialObjPositionY + objOffsetBackRudder - 0.1F, 0);
				transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                leftRot = true;
                print("Left stopped");
                print(transform.eulerAngles.y);
			}
			// Want to be able to rotate CW from 0 to 20, OR from 340 (- 10) to 360
            else if (transform.eulerAngles.y < initialObjPositionY + objOffsetBackRudder || transform.eulerAngles.y >= overflowDegree - 10)
            {
                transform.Rotate(0, speed, 0);
                rightRot = false;
            }
        }
		else if (head.transform.eulerAngles.y < initialOffset.y - 2 && !rightRot) {
			float speed = (float) ((head.transform.eulerAngles.y - (initialOffset.y - 2)) / 20); 
			
			if ((transform.eulerAngles.y > initialObjPositionY + objOffsetBackRudder) && transform.eulerAngles.y < overflowDegree && transform.eulerAngles.y > 180) {
				Quaternion target = Quaternion.Euler (0, overflowDegree + 0.1F, 0);
				transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                rightRot = true;
                print("Right stopped");
                print(transform.eulerAngles.y);
			}
			// Want to be able to rotate CCW from 20 (+ 10) to 0, OR 360 to 340
            else if (transform.eulerAngles.y < initialObjPositionY + objOffsetBackRudder + 10 || transform.eulerAngles.y >= overflowDegree)
            {
                transform.Rotate(0, speed, 0);
                leftRot = false;
            }

        }
	}

}
