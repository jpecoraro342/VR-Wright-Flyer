using UnityEngine;
using System.Collections;

public class ObjectReset : MonoBehaviour {

	public GameObject objectToReset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Cardboard.SDK.Triggered) {
			resetRigidBody(objectToReset);
		}
	}

	IEnumerator resetRigidBody(GameObject gobject) {
		Debug.Log("Reset Object");
		gobject.transform.localPosition = Vector3.zero;

		var rigidbody = gobject.GetComponent<Rigidbody>();

		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;

		rigidbody.Sleep();

		yield return new WaitForSeconds(1.0f);

		rigidbody.WakeUp();
	}
}
