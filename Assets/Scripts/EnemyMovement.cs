using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
  public int side;
  public float slowDuration;
  public float accelDuration;

  public bool inSlomoRadius;
  public bool isSlowed;

  public bool inAccelRadius;
  public bool isAcceled;

  public void updateSlomo () {
    print(slowDuration);
    if (inSlomoRadius) {
      slowDuration += Time.deltaTime*2;
      isSlowed = true;
      applySlowmo();
    } else if (isSlowed) {
      slowDuration -= Time.deltaTime;
      if (slowDuration <= 0) {
        slowDuration = 0;
        isSlowed = false;
        removeSlomo();
      }
    }

    if (inAccelRadius) {
      accelDuration += Time.deltaTime*2;
      isAcceled = true;
      applySlowmo();
    } else if (isAcceled) {
      accelDuration -= Time.deltaTime;
      if (accelDuration <= 0) {
        accelDuration = 0;
        isAcceled = false;
        removeSlomo();
      }
    }
  }

  void applySlowmo() {
    float speedMod = 1f;
    if (isSlowed) {
      speedMod -= 0.5f;
    }
    if (isAcceled) {
      speedMod += 0.5f;
    }
    gameObject.GetComponent<MovementBehaviour>().speed = gameObject.GetComponent<MovementBehaviour>().defaultSpeed*speedMod;
    Color c = new Vector4(0.5F, 1, 0.5F, 1);
    gameObject.GetComponent<SpriteRenderer>().color = c;
  }

  public void removeSlomo() {
    gameObject.GetComponent<MovementBehaviour>().speed = gameObject.GetComponent<MovementBehaviour>().defaultSpeed;
    gameObject.GetComponent<SpriteRenderer>().color = Color.white;
  }
}
