using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BirdController : MonoBehaviour {

    int rndNumberOfEnemyBirds;
    public List<GameObject> EnemyBirds;
    public bool BirdsCanMove = false;

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
        EnableBirds();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void EnableBirds()
    {
        rndNumberOfEnemyBirds = Random.Range(0, EnemyBirds.Count);
        for (int i = 0; i <= rndNumberOfEnemyBirds; i++)
        {
            EnemyBirds[i].SetActive(true);
        }
    }
}
