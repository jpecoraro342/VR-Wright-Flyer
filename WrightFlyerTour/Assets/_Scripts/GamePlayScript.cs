using UnityEngine;
using System.Collections;

public class GamePlayScript : MonoBehaviour {

	public GameObject kittyHawkNCOpeningCanvasObject;
	public SubtitleManager subtitleManager;
	public OrvilleMovementManager orvilleManager;
	public Autowalk walkScript;
	public GameObject tapToToggleWalkCanvasObject;
	public GameObject wilburWayPoint;
	public GameObject tapToContinueToPlaneCanvas;
	public GameObject tapToEnterPlaneCanvas;

	public AirplaneStartReset airplaneControllerScript;
//	public RotatingVRHead rotationVRHeadScript;
//	public GameObject vrHead;
	public TutorialSegment tutScript;

	public GameObject startingCamera;
	public GameObject startingRenderer;
	public GameObject airplaneCardboard;
	public GameObject airplaneHead;

	public GameObject tapToTurnEngineOn;
	public GameObject tapToFly;

	TriggerManager currentTriggerManager;

	private delegate void TriggerManager();


	// Use this for initialization
	void Start () {
		currentTriggerManager = openingTriggerManager;
		airplaneControllerScript.disablePitchMovement();
		airplaneControllerScript.disableRollMovement();
		airplaneControllerScript.disableYawMovement();
	}
	
	// Update is called once per frame
	void Update () {
		if (Cardboard.SDK.Triggered) {
			if (currentTriggerManager != null) {
				Debug.Log("Cardboard Triggered");
				currentTriggerManager();
				// skipToFlying();
			}
		}
	}

	void skipToFlying() {
		startingCamera.SetActive(false);
		startingRenderer.SetActive(false);
		airplaneCardboard.SetActive(true);
		// Cardboard.SDK.Recenter();

		airplaneControllerScript.enablePitchMovement();
		airplaneControllerScript.enableRollMovement();
		airplaneControllerScript.enableYawMovement();
		airplaneControllerScript.turnEngineOn();

		startFlying();
	}

	void openingTriggerManager() {
		kittyHawkNCOpeningCanvasObject.SetActive(false);
		currentTriggerManager = null;
		orvilleFirstLine();
	}

	void orvilleFirstLine() {
		orvilleManager.startTalking();

		var subtitle = "Orville: \"It’s quite fascinating we came all the way from working on bicycles to working on flying machines, eh Wilbur?\"";

		subtitleManager.playSubtitleForTime(subtitle, 7f, endOrvilleFirstLine);
	}

	void endOrvilleFirstLine() {
		orvilleManager.stopTalking();

		StartCoroutine(startOrvilleSecondLine());
	}

	IEnumerator startOrvilleSecondLine() {
		yield return new WaitForSeconds(1f);

		orvilleManager.startTalking();

		var subtitle = "Orville: \"Well, come along and follow me to the glider so we can get your last flight of the day in!\"";

		subtitleManager.playSubtitleForTime(subtitle, 5f, endOrvilleSecondLine);

		orvilleManager.startMovingToPlane();

		walkScript.enabled = true;
		tapToToggleWalkCanvasObject.SetActive(true);
		currentTriggerManager = startedWalkingToPlane;
	}

	void endOrvilleSecondLine() {
		startOrvilleThirdLine();
	}

	void startOrvilleThirdLine() {
		// Stop current audio
		// set new audio file
		// start playing audio
		subtitleManager.playSubtitleForTime("Orville: \"I still can’t believe we finally flew our first successful flight today! I was off the ground for a whole 12 seconds and 112 feet.\"", 8f, startOrvilleFourthLine);
	}
		
	void startOrvilleFourthLine() {
		subtitleManager.playSubtitleForTime("Orville: \"That flight and the other ones today have been much more successful than that one three days ago.\"", 6f, startOrvilleFifthLine);
	}

	void startOrvilleFifthLine() {
		subtitleManager.playSubtitleForTime("Orville: \"If I recall correctly, you got up for a few seconds on that flight before crashing.\"", 6f, startOrvilleSixthLine);
	}

	void startOrvilleSixthLine() {
		subtitleManager.playSubtitleForTime("Orville: \"Now that we have the front elevator fixed, we’ve been doing much better. The 21 mile per hour headwind helps a lot too.\"", 6f, endOrvilleWalkSequence);
	}

	void endOrvilleWalkSequence() {
		orvilleManager.stopTalking();
	}

	void startedWalkingToPlane() {
		tapToToggleWalkCanvasObject.SetActive(false);
		currentTriggerManager = null;
	}

	public void wilburReachedWayPoint() {
		wilburWayPoint.SetActive(false);
		walkScript.enabled = false;
		StartCoroutine(waitBeforeLettingTap());
	}

	IEnumerator waitBeforeLettingTap() {
		yield return new WaitForSeconds(1f);

		tapToContinueToPlaneCanvas.SetActive(true);

		currentTriggerManager = startOrvillePlaneInstructions;
	}

	void startOrvillePlaneInstructions() {
		currentTriggerManager = null;

		tapToContinueToPlaneCanvas.SetActive(false);

		orvilleManager.startTalking();
		var subtitle = "Orville: \"Alright, just to refresh you, let’s go over the innovative functions of our flyer that makes it different than anything else, the three-axis control. Go ahead and take a look at the back rudder.\"";
		subtitleManager.playSubtitleForTime(subtitle, 11f, startRearRudderSequence);
	}

	public void startRearRudderSequence() {
		var subtitle = "Orville: \"As you may recall, the back rudder controls the yaw of our glider. Just like you would rotate your head to look left and right, the yaw allows us to swivel left and right. Try simulating this with your head right now.\"";
		subtitleManager.playSubtitleForTime(subtitle, 11f, showYawMovementIcon);
	}

	void showYawMovementIcon() {
		//vrHead.SetActive(true);
		//rotationVRHeadScript.startYawRotate();

		//airplaneControllerScript.enablePitchMovement();
		airplaneControllerScript.enableRollMovement();
		airplaneControllerScript.enableYawMovement();
		tutScript.enabled = true;
	}

	public void startRollText() {
		orvilleManager.startTalking();
		var subtitle = "Orville: \"Good job. Just as important as the yaw, is the roll. The roll moves the glider in the same way that you would roll your head to touch your ears to your shoulders. This is accomplished by wing warping, or the slight contortion of the wings to achieve a roll-like movement in the air. Go ahead and try simulating this with your head.\"";
		subtitleManager.playSubtitleForTime(subtitle, 15f, null);
	}

	public void startMoveToPlane() {
		var subtitle = "Orville: \"Nice job! Surprisingly, both the yaw and the roll are controlled by a U-shaped hip cradle in the middle of the cockpit. Why don’t you hop in and try it out?\"";
		subtitleManager.playSubtitleForTime(subtitle, 10f, showYawMovementIcon);

		currentTriggerManager = enterPlane;
		tapToEnterPlaneCanvas.SetActive(true);
	}

	public void enterPlane() {
		orvilleManager.stopTalking();
		tapToEnterPlaneCanvas.SetActive(false);
		currentTriggerManager = null;

		startingCamera.SetActive(false);
		startingRenderer.SetActive(false);
		airplaneCardboard.SetActive(true);
		// Cardboard.SDK.Recenter();

		// Start the tutorial segment for pitch
		airplaneControllerScript.enablePitchMovement();

		tutScript.startFrontRudder();
	}

	public void startPitchText() {
		var subtitle = "Orville: \"Okay Wilbur! Right in front of you is a lever that controls the front elevator. The elevator controls the pitch of the flyer. It moves the flyer in an up-down motion, essential for giving the flyer lift in the air. Why don’t you give it a try?\"";
		subtitleManager.playSubtitleForTime(subtitle, 10f, null);
	}

	public void startEngineTutorialSegment() {
		tutScript.enabled = false;

		var subtitle = "Orville: \"Nice Wilbur! Alright, now that you understand the roll, pitch, and yaw, why don’t we get you flying? As you may recall, our engine there to your right moves a bicycle chain which is connected to the two propellers in the back. It is quite revolutionary. Go ahead and fire it up!\"";
		subtitleManager.playSubtitleForTime(subtitle, 16f, null);

		tapToTurnEngineOn.SetActive(true);
		currentTriggerManager = turnOnEngine;
	}

	public void turnOnEngine() {
		tapToTurnEngineOn.SetActive(false);
		currentTriggerManager = null;

		airplaneControllerScript.turnEngineOn();
		lastFrikingThingToSay();
	}

	public void lastFrikingThingToSay() {
		var subtitle = "Orville: \"Okay, Wilbur! Why don’t you give it a test flight whenever you are ready!\"";
		subtitleManager.playSubtitleForTime(subtitle, 4f, null);
		tapToFly.SetActive(true);
		currentTriggerManager = startFlying;
	}

	public void startFlying() {
		tapToFly.SetActive(false);

		airplaneControllerScript.enablePlaneMovement();

	}
}
