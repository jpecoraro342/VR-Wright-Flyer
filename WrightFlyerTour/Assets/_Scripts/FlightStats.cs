using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlightStats : MonoBehaviour {

	public Text Speed;
	public Text Distance;
	public Text AirTime;

	public float transformToFeetConversionFactor;

	private float flightThreshold = 1;

	private float speed;
	private float distance;
	private float flightTime;

	private Vector3 previousLocation;

	// Use this for initialization
	void Start () {
		previousLocation = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		spinMeter();
		var distanceSinceLastUpdate = (transform.position - previousLocation).magnitude * transformToFeetConversionFactor;

		setDistance(distance + distanceSinceLastUpdate);
		setSpeed(distanceSinceLastUpdate/Time.deltaTime * 0.681818f); // Converts fps to mph

		if (transform.position.y >= flightThreshold) {
			setFlightTime(flightTime + Time.deltaTime);
		}

		previousLocation = transform.position;
	}

	void setSpeed(float speed) {
		this.speed = speed;

		if (Speed != null) {
			Speed.text = "Speed: " + speed.ToString("n2") + " mph";
		}
		else {
			Debug.Log("Speed: " + speed.ToString("n2") + " mph");
		}
	}

	void setDistance(float distance) {
		this.distance = distance;

		if (Distance != null) {
			Distance.text = "Distance Traveled: " + distance.ToString("n2") + " ft";
		}
		else {
			Debug.Log("Distance Traveled: " + distance.ToString("n2") + " ft");
		}
	}

	void setFlightTime(float flightTime) {
		this.flightTime = flightTime;

		if (Speed != null) {
			AirTime.text = "Air Time: " + flightTime.ToString("n2") + " sec";
		}
		else {
			Debug.Log("Air Time: " + flightTime.ToString("n2") + " sec");
		}
	}

	void spinMeter() {
		GameObject go = GameObject.Find("Wind_meter");
		float rotSpeed = -2.5F - (speed / 10);
		rotSpeed = 1.4F * rotSpeed;  // Scale it a bit
		go.transform.Rotate(0, 0, rotSpeed);
	}

}
