using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirdController : MonoBehaviour {
    int rndNumberOfItems;
    List<GameObject> EnemyBirds;
    
	// Use this for initialization
	void Start () {
        rndNumberOfItems = Random.Range(0, EnemyBirds.Count);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
