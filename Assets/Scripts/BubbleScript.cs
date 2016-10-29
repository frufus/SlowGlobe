using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {


	const float maxThresholdTop = 3.0f;
	const float maxThresholdBottom = -3.0f;
	const float maxThresholdLeft = -5.0f;
	const float maxThresholdRight = 5.0f;

	float baseSpeed;
	string directionX = "left";
	string directionY = "top";
	float thresholdXleft;
	float thresholdXright;
	float thresholdYtop;
	float thresholdYbottom;
	Vector3 pos;

	MovementBehaviour movement;

	// Use this for initialization
	void Start () {
		movement = GetComponent<MovementBehaviour>();
		movement.defaultSpeed = 2f;

		thresholdXleft = Random.Range(maxThresholdLeft, 0.0f);
		thresholdXright = Random.Range(0.0f, maxThresholdRight);
		thresholdYtop = Random.Range(0.0f, maxThresholdTop);
		thresholdYbottom = Random.Range(maxThresholdBottom, 0.0f);
	}

	// Update is called once per frame
	void Update () {
		baseSpeed = Time.deltaTime * movement.speed;
		pos = transform.position;
		ToggleX ();
		ToggleY ();
	}

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
		}
	}
}
