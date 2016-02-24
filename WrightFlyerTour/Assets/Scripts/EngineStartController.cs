using UnityEngine;
using System.Collections;

public class EngineStartController : MonoBehaviour {

	public GameObject propeller1;
	public GameObject propeller2;

	public bool isEngineOn = false;

	public float raycastLength = 20f;
	public float rotationsPerMinute = 30.0f; 

	private RaycastHit hitInfo;
 	private Ray ray;
    private bool didRayHit = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ray = new Ray(transform.position, transform.forward);
	 	didRayHit = Physics.Raycast(ray, out hitInfo, raycastLength);
	 	if (didRayHit)
		{
	     print("I am a" + raycastLength + " unit long ray hitting " + hitInfo.transform.name);
	    // engineOn();
	     //hitInfo.doAnimationStuffHere;
	    }

	    engineOn();
	}


	void engineOn () {

		propeller1.transform.Rotate(20.0f * rotationsPerMinute * Time.deltaTime, 0.0f, 0.0f);
		propeller2.transform.Rotate(20.0f * rotationsPerMinute * Time.deltaTime, 0.0f, 0.0f);

	}
}
