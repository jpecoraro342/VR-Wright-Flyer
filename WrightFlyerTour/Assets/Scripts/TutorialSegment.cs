using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Just attach this script to any game object and it will play. For example:
/*

			GameObject go = GameObject.Find("Center-flyer");
			go.AddComponent<TutorialSegment>();

*/
public class TutorialSegment : MonoBehaviour {

	private bool completedWingL = true;
	private bool completedWingR = true;
	private bool completedBackRudL = true;
	private bool completedBackRudR = true;
	private bool completedFrontRudL = false;
	private bool completedFrontRudR = false;
	private bool gotOnPlane = false;

	public Text tutText;
	public Image panel;


	// Use this for initialization
	void Start () {
		tutText.text = "";
		// panel.gameObject.SetActive(true);	// Panel is set inactive in the Autowalk script
	}
	
	// Update is called once per frame
	void Update () {
		panel.gameObject.SetActive(true);
		if (!completedWingR) {
			rollTut ();
		}
		else if (!completedBackRudR) {
			backRudderTut();
		}
		/*
		else if (!gotOnPlane) {
			getOnPlane();
		}
		*/
		else if (!completedFrontRudR) {
			frontRudderTut ();
		}
		else {
			enabled = false;  // Turns off this script
			tutText.text = "";
			panel.gameObject.SetActive(false);
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
		GameObject go = GameObject.Find("Front Pivot");
		if (!completedFrontRudL) {
			tutText.text = "Now let's look down to pitch downwards";
			if (go.transform.eulerAngles.x < 342 && go.transform.eulerAngles.x > 180) {
				//tutText.CrossFadeAlpha(0.0f, 0.5f, false);
				completedFrontRudL = true;
			}
		}

		else {

			tutText.text = "Let's try looking up";
			//tutText.CrossFadeAlpha(1.0f, 2.5f, false);
			if (go.transform.eulerAngles.x > 18 && go.transform.eulerAngles.x < 180) {
				completedFrontRudR = true;
				//enabled = false;
			}


		}
	}

/*
	void getOnPlane() {
		GameObject go = GameObject.Find("Character");
		Vector3 first = new Vector3(-1, 0, 1);
		go.transform.Translate(first * Time.deltaTime);
	}
*/
}
