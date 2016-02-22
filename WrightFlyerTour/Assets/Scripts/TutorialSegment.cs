using UnityEngine;
using System.Collections;

// Just attach this script to any game object and it will play. For example:
/*

			GameObject go = GameObject.Find("Center-flyer");
			go.AddComponent<TutorialSegment>();

*/
public class TutorialSegment : MonoBehaviour {

	private bool completedWingL = false;
	private bool completedWingR = false;
	private bool completedBackRudL = false;
	private bool completedBackRudR = false;
	private bool completedFrontRudL = false;
	private bool completedFrontRudR = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!completedWingR) {
			rollTut ();
		}
		else if (!completedBackRudR) {
			backRudderTut();
		}
		/*
		else if (!completedFrontRudR) {

		}
		*/
		else {
			enabled = false;  // Turns off this script
		}
	}

	void backRudderTut () {
		GameObject go = GameObject.Find("Back_Rudder");
		if (!completedBackRudL) {
			print("Turn your head left to control the yaw");
			if (go.transform.eulerAngles.y < 340 && go.transform.eulerAngles.y > 180) {
				completedBackRudL = true;
				print("Good!");
			}
		}

		else {
			print("Look right to move the rudder right.");
			if (go.transform.eulerAngles.y > 18 && go.transform.eulerAngles.y < 180) {
				print("Great job!");
				completedBackRudR = true;
				//enabled = false;
			}


		}
	}

	void rollTut () {
		GameObject go = GameObject.Find("Center-flyer");
		if (!completedWingL) {
			print("Try tilting left to control the roll");
			if (go.transform.eulerAngles.z < 358 && go.transform.eulerAngles.z > 180) {
				completedWingL = true;
				print("Good!");
			}
		}

		else {
			print("Try tilting right now");
			if (go.transform.eulerAngles.z > 2 && go.transform.eulerAngles.z < 180) {
				print("Great job!");
				completedWingR = true;
				//enabled = false;
			}


		}
	}

	void frontRudderTut () {

	}
}
