using UnityEngine;
using System.Collections;

public class RocketMovement : EnemyMovement {

  private Vector3 startPosition;
  public bool canMove = false;
  MovementBehaviour movement;

  // Use this for initialization
  void Start () {
    movement = GetComponent<MovementBehaviour>();
    startPosition = transform.position;

    if (side == 0) {
      movement.direction = new Vector3(Random.Range(10, 50), Random.Range(-20, 10), 0);
    } else {
      movement.direction = new Vector3(Random.Range(-50, -10), Random.Range(-20, 10), 0);
    }
    movement.direction.Normalize();
    movement.defaultSpeed = Random.Range(.04f, .07f);
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
        transform.Translate(movement.direction * movement.speed);
      }
    }
  }
}
