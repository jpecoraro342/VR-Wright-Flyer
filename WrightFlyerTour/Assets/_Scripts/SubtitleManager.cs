using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubtitleManager : MonoBehaviour {

	public Canvas subtitleCanvas;
	public Text subtitleText;

	public GameObject subtitleTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator playSubtitleForTime(string text, float duration) {
		subtitleText.text = text;
		subtitleCanvas.enabled = true;

		yield return new WaitForSeconds(duration);

		subtitleCanvas.enabled = false;
		subtitleText.text = "";
	}
}
