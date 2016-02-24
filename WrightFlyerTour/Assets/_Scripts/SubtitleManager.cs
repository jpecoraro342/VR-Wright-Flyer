using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubtitleManager : MonoBehaviour {

	public Canvas subtitleCanvas;
	public Text subtitleText;

	public GameObject subtitleTarget;

	public delegate void OnSubtitleFinished();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator playSubtitleForTime(string text, float duration, OnSubtitleFinished completionFunction) {
		subtitleText.text = text;
		subtitleCanvas.enabled = true;

		yield return new WaitForSeconds(duration);

		subtitleCanvas.enabled = false;
		subtitleText.text = "";

		if (completionFunction != null) {
			completionFunction();
		}
	}

	// Note: These are for testing only!

	void testSubtitleSequence() {
		StartCoroutine(playSubtitleForTime("This is the first title in the subtitle sequence. We are testing to see how well this works. This is displayed for 10 seconds", 10, subtitleOneFinished));
	}

	void subtitleOneFinished() {
		StartCoroutine(playSubtitleForTime("This is a shorter subtitle that only displays for 3 seconds", 3, subtitleTwoFinished));
	}

	void subtitleTwoFinished() {
		StartCoroutine(playSubtitleForTime("Wilbur is blah blah blah. He blah blah blah and does some really cool other stuff. Displaying this subtitle for 4 whole seconds", 4, subtitleThreeFinished));
	}

	void subtitleThreeFinished() {
		StartCoroutine(playSubtitleForTime("We will finish in 3.. 2.. 1..", 4, null));
	}
}
