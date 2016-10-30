using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            GameController.Instance.Bubble.GetComponent<Animator>().SetTrigger("CollidedWithEnemy");
            GameController.Instance.PauseTimer();
            StartCoroutine(StartGameOverStreen(.5f));
        }
            
        Debug.Log("Collision detected");
    }

    private IEnumerator StartGameOverStreen(float waitseconds)
    {
        yield return new WaitForSeconds(waitseconds);
        GameController.Instance.Background.GetComponent<BackgroundMovement>().enabled = false;
        GameController.Instance.GameOverGO.SetActive(true);
        Cursor.visible = true;
    }
    /*void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Collision detected");
    }*/
}
