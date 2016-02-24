using UnityEngine;
using System.Collections;

public class PropellerRotate : MonoBehaviour {

	public float rotationsPerMinute = 10.0f; 

	
	// Update is called once per frame
	void Update () {

			transform.Rotate(0.0f, 6.0f * rotationsPerMinute * Time.deltaTime, 0.0f);
	}
}
