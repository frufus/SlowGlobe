using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {


	const float maxThresholdTop = 3.0f;
	const float maxThresholdBottom = -3.0f;
	const float maxThresholdLeft = -5.0f;
	const float maxThresholdRight = 5.0f;

	float baseSpeed;
	Vector3 pos;
	Vector3 target;
	Vector3 nextTarget;

	MovementBehaviour movement;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		movement = GetComponent<MovementBehaviour>();
		movement.defaultSpeed = 2f;

		thresholdXleft = Random.Range(maxThresholdLeft, 0.0f);
		thresholdXright = Random.Range(0.0f, maxThresholdRight);
		thresholdYtop = Random.Range(0.0f, maxThresholdTop);
		thresholdYbottom = Random.Range(maxThresholdBottom, 0.0f);
=======
		SetNewTarget ();
>>>>>>> Nico
	}

	// Update is called once per frame
	void Update () {
		baseSpeed = Time.deltaTime * movement.speed;
		pos = transform.position;
		Move ();

	}

<<<<<<< HEAD
	void ToggleX(){
		if (directionX == "left") {
			float speed = baseSpeed;
			if (pos.x > thresholdXleft) {
				transform.Translate (Vector3.left * speed);
			} else {
				directionX = "right";
				thresholdXright = Random.Range(0.0f, maxThresholdRight);
			}
		} else if (directionX == "right") {
			float speed = baseSpeed;
			if (pos.x < thresholdXright) {
				transform.Translate (Vector3.right * speed);
			} else {
				directionX = "left";
				thresholdXleft = Random.Range(maxThresholdLeft, 0.0f);
			}
		}
	}

	void ToggleY(){
		if (directionY == "top") {
			float speed = baseSpeed;
			if (pos.y < thresholdYtop) {
				transform.Translate (Vector3.up * speed);
			} else {
				directionY = "bottom";
				thresholdYbottom = Random.Range(maxThresholdBottom, 0.0f);
			}
		} else if (directionY == "bottom") {
			float speed = baseSpeed;
			if (pos.y > thresholdYbottom) {
				transform.Translate (Vector3.down * speed);
			} else {
				directionY = "top";
				thresholdYtop = Random.Range(0.0f, maxThresholdTop);
			}
=======
	void Move() {

		float distance = Vector3.Distance (transform.position, target);
		float distanceNext = Vector3.Distance (transform.position, nextTarget);


		if (distance < 1.5f) {
			print ("before: " + target.ToString());
			target = Vector3.Slerp (target, nextTarget , baseSpeed);

			print ("after: " + target.ToString());

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
>>>>>>> Nico
		}

	}

	void SetTargetX() {
		target = new Vector3 (Random.Range (maxThresholdLeft, maxThresholdRight), target.y, 0f);
	}
	void SetTargetY() {
		target = new Vector3 (target.x, Random.Range (maxThresholdBottom, maxThresholdTop), 0f);
	}
		
}
