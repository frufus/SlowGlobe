using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirdController : MonoBehaviour {

    int rndNumberOfItems;
    public List<GameObject> EnemyBirds;

    private static BirdController instance = null;
    public static BirdController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<BirdController>();
            }
            return instance;
        }
    }
    // Use this for initialization
    void Start () {
        rndNumberOfItems = Random.Range(0, EnemyBirds.Count);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
