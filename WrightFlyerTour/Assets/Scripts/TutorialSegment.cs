using UnityEngine;
using UnityEngine.UI;
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

	public Text tutText;


	// Use this for initialization
	void Start () {
		tutText.text = "";
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
			tutText.text = "Turn your head left to control the yaw";
			print("Turn your head left to control the yaw");
			if (go.transform.eulerAngles.y < 340 && go.transform.eulerAngles.y > 180) {
				completedBackRudL = true;
				print("Good!");
			}
		}

		else {
			tutText.text = "Look right to move the rudder right";
			print("Look right to move the rudder right.");
			if (go.transform.eulerAngles.y > 18 && go.transform.eulerAngles.y < 180) {
				tutText.text = "";
				print("Great job!");
				completedBackRudR = true;
				//enabled = false;
			}


		}
	}

	void rollTut () {
		GameObject go = GameObject.Find("Center-flyer");
		if (!completedWingL) {
			tutText.text = "Try tilting your head left to control the roll";
			print("Try tilting left to control the roll");
			if (go.transform.eulerAngles.z < 358 && go.transform.eulerAngles.z > 180) {
				//tutText.CrossFadeAlpha(0.0f, 0.5f, false);
				completedWingL = true;
				print("Good!");
			}
		}

		else {

			tutText.text = "Try tilting right now";
			//tutText.CrossFadeAlpha(1.0f, 2.5f, false);
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
