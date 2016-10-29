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
		EnemyMovement em = gameObject.GetComponent<EnemyMovement>();
		if (em != null) {
			gameObject.GetComponent<EnemyMovement>().inAccelRadius = false;
	    	gameObject.GetComponent<EnemyMovement>().inSlomoRadius = false;
		}
	}
}
