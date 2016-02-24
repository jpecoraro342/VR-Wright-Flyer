using UnityEngine;
using System.Collections;

public class ElevatorController : MonoBehaviour {

	public float smooth = 2.0F;

	private CardboardHead head;
	private Vector3 initialOffset;
	private float initialObjPositionX;
	private float objOffsetElevator = 20F;

	// 0 degrees == 360 degrees... take that into account
	private float overflowDegree = 0F;

	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController>().Head;
		initialOffset = head.transform.eulerAngles;

		//Elevator Initial Elements (including handlebar)
		initialObjPositionX = transform.eulerAngles.x;
		//if (initialObjPositionX - objOffsetElevator < 0) {
	//		overflowDegree = 360 + (initialObjPositionX - objOffsetElevator);
		//}
	}
	
	// Update is called once per frame
	void Update () {
		print ("head transform: "+ head.transform.eulerAngles.x);
		print ("elevator transform: " + transform.eulerAngles.x);
		elevatorControl ();
	}


	void elevatorControl() {
		if ( (head.transform.eulerAngles.x > initialOffset.x + 2) && (head.transform.eulerAngles.x < 180) ) {
			float speed = (float) (head.transform.eulerAngles.x / 20); 
			if (  (transform.eulerAngles.x >= (360 - objOffsetElevator + initialObjPositionX) ) || (transform.eulerAngles.x <= (initialObjPositionX + objOffsetElevator) ) ) { //  && ( (transform.eulerAngles.x > (360 - objOffsetElevator) ) )  {
				transform.Rotate (-speed, 0, 0);
				if (  (transform.eulerAngles.x < (initialObjPositionX + objOffsetElevator + 5)) && (transform.eulerAngles.x > (initialObjPositionX + objOffsetElevator) ) ) {
					
				}
			}

		/*	// Object may get stuck after moving it, so check that it does not over rotate
			if (  (transform.eulerAngles.x > initialObjPositionX + objOffsetElevator) && (transform.eulerAngles.x < 180) ){ // && transform.eulerAngles.x < overflowDegree) {
				Quaternion target = Quaternion.Euler (initialObjPositionX + objOffsetElevator - 0.1F, 0, 0);
				transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			} */
		}
		else if ( (head.transform.eulerAngles.x < (360 - initialOffset.x - 2) ) && (head.transform.eulerAngles.x >= 180) ){
			float speed = (float) ( (360 - head.transform.eulerAngles.x) / 20); 
			if ( (transform.eulerAngles.x > (360 - objOffsetElevator + initialObjPositionX) ) || (transform.eulerAngles.x < initialObjPositionX + objOffsetElevator ) ) { // && ( (transform.eulerAngles.x > (360 - objOffsetElevator) ) ) {
				transform.Rotate (speed, 0, 0);
			}

		/*	if ((transform.eulerAngles.x > initialObjPositionX + objOffsetElevator)) { // && transform.eulerAngles.x < overflowDegree) {
				Quaternion target = Quaternion.Euler (overflowDegree + 0.1F, 0, 0);
				transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
			}*/
		} 
	}

}
