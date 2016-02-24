using UnityEngine;
using System.Collections;

public class MobileTiltControlsManager : MonoBehaviour {

	public float roll { get; set; }
	public float pitch { get; set;}
	public float yaw {get; set; }

	public float minVal;
	public float maxVal;

	// You should use the cardboard head for this
	public GameObject mainCharacter;

	// Use this for initialization
	void Start () {
		// TODO: Use transform.forward of airplane as initial neutral position
	}
	
	// Update is called once per frame
	void Update () {
		var direction = mainCharacter.transform.localEulerAngles;

		roll = -1*getComputedValue(direction.z); 
		pitch = getComputedValue(direction.x);
		yaw = getComputedValue(direction.y);
	}

	float getComputedValue(float angle) {
		var adjusted = getAdjustedAngle(angle);
		// var trimmed = Mathf.Clamp(adjusted, minVal, maxVal);
		return scaleDown(adjusted, 180);
	}

	float getAdjustedAngle(float angle) {
		if (angle > 180) {
			return angle-360;
		}
		return angle;
	}

	float scaleDown(float val, float scale) {
		return val/scale;
	}
}
