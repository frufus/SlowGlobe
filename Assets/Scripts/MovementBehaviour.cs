using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour {

    public Vector3 direction;
    public float speed;
    public float defaultSpeed;

	// Use this for initialization
	void Start () {

	}

	void Update () {
      GetComponent<SpriteRenderer>().color = Color.white;
      speed = defaultSpeed;
	}
}
