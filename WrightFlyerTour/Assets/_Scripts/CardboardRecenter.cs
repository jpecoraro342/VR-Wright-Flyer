using UnityEngine;
using System.Collections;

public class CardboardRecenter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Recenter();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Recenter() {
		Debug.Log("recenter");
		Transform reference = transform.parent;
		if (reference != null) {
			reference.rotation = Quaternion.Inverse(transform.rotation) * reference.rotation;
			// next line is optional -- try it with and without
			// reference.rotation = Quaternion.FromToRotation(reference.up, Vector3.up) * reference.rotation;
		}
	}
}
