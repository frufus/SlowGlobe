using UnityEngine;
using System.Collections;

public class ThunderMovement : EnemyMovement {

  private Vector3 startPosition;
  public bool canMove = false;
  MovementBehaviour movement;

  // Use this for initialization
  void Start () {
    movement = GetComponent<MovementBehaviour>();
    startPosition = transform.position;

    if (side == 0) {
      movement.direction = new Vector3(Random.Range(10, 50), Random.Range(-5, 5), 0);
    } else {
      movement.direction = new Vector3(Random.Range(-50, -10), Random.Range(-5, 5), 0);
    }
    movement.direction.Normalize();
    movement.defaultSpeed = Random.Range(.05f, .1f);
    movement.speed = movement.defaultSpeed;
  }

  // Update is called once per frame
  void Update () {
    if(transform.position.x < -11 || transform.position.x > 11)
    {
      gameObject.SetActive(false);
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
