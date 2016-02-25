using UnityEngine;
using System.Collections;

public class OrvilleMovementManager : MonoBehaviour {

	public float speed;
	public Transform movementTarget;

	Animator animator;

	float currentSpeed;
	bool isTalking;
	bool isMovingTowardPlane;

	Vector3 previousPosition;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		previousPosition = transform.position;

		StartCoroutine(runTestSequence());
	}

	void Update () {
		if (isMovingTowardPlane) {
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, movementTarget.position, step);

			if (transform.position == movementTarget.position) {
				isMovingTowardPlane = false;
			}
		}

		currentSpeed = (transform.position - previousPosition).magnitude / Time.deltaTime;
		animator.SetFloat("Speed", currentSpeed);

		previousPosition = transform.position;
	}

	public void startMovingToPlane() {
		isMovingTowardPlane = true;
	}

	public void startTalking() {
		isTalking = true;
		animator.SetBool("Talking", isTalking);
	}

	public void stopTalking() {
		isTalking = false;
		animator.SetBool("Talking", isTalking);
	}

	public void point() {
		animator.SetTrigger("Pointing");
	}

	IEnumerator runTestSequence() { 
		yield return new WaitForSeconds(4);

		startTalking();

		yield return new WaitForSeconds(7);

		stopTalking();

		point();

		yield return new WaitForSeconds(3);

		startMovingToPlane();

		yield return new WaitForSeconds(3);

		startTalking();
	}
}
