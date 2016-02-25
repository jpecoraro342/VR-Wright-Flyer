using UnityEngine;
using System.Collections;

public class GamePlayScript : MonoBehaviour {

	public GameObject kittyHawkNCOpeningCanvasObject;
	public SubtitleManager subtitleManager;
	public OrvilleMovementManager orvilleManager;
	public Autowalk walkScript;
	public GameObject tapToToggleWalkCanvasObject;
	public GameObject wilburWayPoint;

	TriggerManager currentTriggerManager;

	private delegate void TriggerManager();


	// Use this for initialization
	void Start () {
		currentTriggerManager = openingTriggerManager;
	}
	
	// Update is called once per frame
	void Update () {
		if (Cardboard.SDK.Triggered) {
			if (currentTriggerManager != null) {
				Debug.Log("Cardboard Triggered");
				currentTriggerManager();
			}
		}
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
		Debug.Log("Start all the plane crap");
		wilburWayPoint.SetActive(false);
		walkScript.enabled = false;
	}

	void startOrvillePlaneInstructions() {

	}
}
