using UnityEngine;
using System.Collections;

public class GamePlayScript : MonoBehaviour {

	public GameObject kittyHawkNCOpeningCanvasObject;
	public SubtitleManager subtitleManager;
	public OrvilleMovementManager orvilleManager;
	public Autowalk walkScript;
	public GameObject tapToToggleWalkCanvasObject;


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
		orvilleManager.stopTalking();
	}

	void startedWalkingToPlane() {
		tapToToggleWalkCanvasObject.SetActive(false);
		currentTriggerManager = null;
	}
}
