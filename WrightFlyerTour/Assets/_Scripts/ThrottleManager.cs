using UnityEngine;
using System.Collections;

public class ThrottleManager : MonoBehaviour {

	private float currentThrottle = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float getThrottle() {
		return currentThrottle;
	}
}
