using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public Vector3 direction;
    public float speed;
    public float defaultSpeed;
    private Vector3 startPosition;
    bool canMove = true;
    
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        direction = new Vector3(Random.Range(10, 50), Random.Range(-2, 5), 0);
        direction.Normalize();

        defaultSpeed = Random.Range(.05f, .1f);
        speed = defaultSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x < -10)
        {
            canMove = false;
            transform.position = startPosition;
            gameObject.SetActive(false);
        }
        else
        {
            if(canMove)
                transform.Translate(-direction * speed);
        }
        
	}
  
    
}
