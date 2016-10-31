using UnityEngine;
using System.Collections;

public class FishMovement : EnemyMovement {

  private Vector3 startPosition;
  public bool canMove = false;
  MovementBehaviour movement;

  // Use this for initialization
  void Start () {
    movement = GetComponent<MovementBehaviour>();
    startPosition = transform.position;

    if (side == 0) {
      movement.direction = new Vector3(Random.Range(10, 50), Random.Range(-10, 0), 0);
    } else {
			GetComponent<SpriteRenderer>().flipX = true;
      movement.direction = new Vector3(Random.Range(-50, -10), Random.Range(-10, 0), 0);
    }
    movement.direction.Normalize();
    movement.defaultSpeed = Random.Range(.02f, .08f);
    movement.speed = movement.defaultSpeed;
  }

  // Update is called once per frame
  void Update () {
    updateSlomo();
    if(transform.position.x < -11 || transform.position.x > 11)
    {
      gameObject.SetActive(false);
      removeSlomo();
      transform.position = startPosition;

    }
    else
    {
      if(canMove) {
        transform.Translate(new Vector3((movement.direction.x * movement.speed), movement.direction.y * 0.2f, 0));
      }
    }
  }
}
