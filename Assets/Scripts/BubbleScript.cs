using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {


	const float maxThresholdTop = 3.0f;
	const float maxThresholdBottom = -3.0f;
	const float maxThresholdLeft = -5.0f;
	const float maxThresholdRight = 5.0f;

	float baseSpeed;
	Vector3 target;
	Vector3 nextTarget;

	MovementBehaviour movement;

	// Use this for initialization
	void Start () {
		movement = GetComponent<MovementBehaviour>();
		movement.defaultSpeed = 2f;
		movement.speed = movement.defaultSpeed;

		SetNewTarget ();
	}

	// Update is called once per frame
	void Update () {
		baseSpeed = Time.deltaTime * movement.speed;
		Move ();

	}

	void Move() {

		float distance = Vector3.Distance (transform.position, target);
		float distanceNext = Vector3.Distance (transform.position, nextTarget);


		if (distance < 1.5f) {
			target = Vector3.Slerp (target, nextTarget , baseSpeed);
			transform.position = Vector3.MoveTowards (transform.position, target, baseSpeed);

		} else {
			transform.position = Vector3.MoveTowards (transform.position, target, baseSpeed);

		}



		if (distance < baseSpeed) {
			SetNewTarget ();
			target = Vector3.Slerp (target, nextTarget , baseSpeed);
		}
	}

	void SetNewTarget(){
		float x = Random.Range (maxThresholdLeft, maxThresholdRight);
		float y = Random.Range (maxThresholdBottom, maxThresholdTop);
		float xNext = Random.Range (maxThresholdLeft, maxThresholdRight);
		float yNext = Random.Range (maxThresholdBottom, maxThresholdTop);
		nextTarget = new Vector3 (xNext, yNext, 0f);
		target = new Vector3 (x, y, 0f);
		while (Vector3.Distance (target, nextTarget) < 1f) {
			SetNewTarget ();
		}

	}

	void SetTargetX() {
		target = new Vector3 (Random.Range (maxThresholdLeft, maxThresholdRight), target.y, 0f);
	}
	void SetTargetY() {
		target = new Vector3 (target.x, Random.Range (maxThresholdBottom, maxThresholdTop), 0f);
	}
		
}
