using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Just attach this script to any game object and it will play. For example:
/*

			GameObject go = GameObject.Find("Center-flyer");
			go.AddComponent<TutorialSegment>();

*/
public class TutorialSegment : MonoBehaviour {

	public GamePlayScript gameplayScript;

	private bool completedWingL = false;
	private bool completedWingR = false;
	private bool completedBackRudL = false;
	private bool completedBackRudR = false;
	private bool completedFrontRudL = false;
	private bool completedFrontRudR = false;
	private bool gotOnPlane = false;

	private bool canStartFrontRudder = false;

	public RotatingVRHead rotationVRHeadScript;
	public GameObject vrHead;

	public RotatingVRHead secondRotationVRHeadScript;
	public GameObject secondVRHead;

//	public Text tutText;
//	public Image panel;

	// Use this for initialization
	void Start () {
		//tutText.text = "";
		// panel.gameObject.SetActive(true);	// Panel is set inactive in the Autowalk script
	}
	
	// Update is called once per frame
	void Update () {
		//panel.gameObject.SetActive(true);

		if (!completedBackRudR) {
			backRudderTut();
		}
		else if (!completedWingR) {
			rollTut ();
		}
		else if (canStartFrontRudder) {
			frontRudderTut();
		}
		/*
		else if (!gotOnPlane) {
			getOnPlane();
		}

		else if (!completedFrontRudR) {
			frontRudderTut ();
		}
		*/
		else {
			// enabled = false;  // Turns off this script
			//tutText.text = "";
			//panel.gameObject.SetActive(false);
		}
	}

	public void backRudderTut () {
		GameObject go = GameObject.Find("Back_Rudder");
		if (!vrHead.activeInHierarchy) {
			vrHead.SetActive(true);
			rotationVRHeadScript.startYawRotate();
			gameplayScript.startRearRudderSequence();
		}
		if (!completedBackRudL) {
			//tutText.text = "Turn your head left to control the yaw";
			//print("Turn your head left to control the yaw");
			if (go.transform.eulerAngles.y < 340 && go.transform.eulerAngles.y > 180) {
				completedBackRudL = true;
				//print("Good!");
			}
		}

		else {
			//tutText.text = "Look right to move the rudder right";
			//print("Look right to move the rudder right.");
			if (go.transform.eulerAngles.y > 18 && go.transform.eulerAngles.y < 180) {
				
				//print("Great job!");
				completedBackRudR = true;
				vrHead.SetActive(false);

				//enabled = false;
			}


		}
	}

	public void rollTut () {
		GameObject go = GameObject.Find("Pivot_For_Flyer");
		if (!vrHead.activeInHierarchy) {
			vrHead.SetActive(true);
			rotationVRHeadScript.startRollRotate();
			gameplayScript.startRollText();

		}
		if (!completedWingL) {
			//tutText.text = "Try tilting your head left to control the roll";
			//print("Try tilting left to control the roll");
			if (go.transform.eulerAngles.z < 358 && go.transform.eulerAngles.z > 180) {
				//tutText.CrossFadeAlpha(0.0f, 0.5f, false);
				completedWingL = true;
				//print("Good!");
			}
		}

		else {

			//tutText.text = "Try tilting right now";
			//tutText.CrossFadeAlpha(1.0f, 2.5f, false);
			//print("Try tilting right now");
			if (go.transform.eulerAngles.z > 2 && go.transform.eulerAngles.z < 180) {
				//print("Great job!");
				completedWingR = true;
				vrHead.SetActive(false);
				//enabled = false;

				gameplayScript.startMoveToPlane();
			}


		}
	}

	public void frontRudderTut () {
		GameObject go = GameObject.Find("Front_rudder");
		if (!secondVRHead.activeInHierarchy) {
			secondVRHead.SetActive(true);
			secondRotationVRHeadScript.startPitchRotate();
			gameplayScript.startPitchText();
		}
		if (!completedFrontRudL) {
			
			//tutText.text = "Now let's look down to pitch downwards";
			if (go.transform.eulerAngles.x < 342 && go.transform.eulerAngles.x > 180) {
				//tutText.CrossFadeAlpha(0.0f, 0.5f, false);
				completedFrontRudL = true;
			}
		}

		else {

			//tutText.text = "Let's try looking up";
			//tutText.CrossFadeAlpha(1.0f, 2.5f, false);
			if (go.transform.eulerAngles.x > 18 && go.transform.eulerAngles.x < 180) {
				completedFrontRudR = true;
				secondVRHead.SetActive(false);
				gameplayScript.startEngineTutorialSegment();
				//enabled = false;
			}
		}
	}

	public void startFrontRudder() {
		canStartFrontRudder = true;
	}

/*
	void getOnPlane() {
		GameObject go = GameObject.Find("Character");
		Vector3 first = new Vector3(-1, 0, 1);
		go.transform.Translate(first * Time.deltaTime);
	}
*/
}
