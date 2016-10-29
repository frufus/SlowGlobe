using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

	private bool mouseDown = false;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			mouseDown = true;
		}
		if (Input.GetMouseButtonUp(0)) {
			mouseDown = false;
		}
		
		Vector3 wm = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		GameObject hl = GameObject.Find("highlight");
		hl.transform.position = new Vector3(wm.x, wm.y, 0);

		List<GameObject> enemies = BirdController.Instance.EnemyBirds;
        foreach (GameObject go in enemies) {
			go.GetComponent<SpriteRenderer>().color = Color.white;
			go.GetComponent<EnemyMovement>().speed = go.GetComponent<EnemyMovement>().defaultSpeed;
		}

		if (mouseDown) {
			Collider2D[] hitColliders = Physics2D.OverlapCircleAll(new Vector2(wm.x, wm.y), 1);
			foreach (Collider2D col in hitColliders) {
				col.GetComponent<EnemyMovement>().speed = col.GetComponent<EnemyMovement>().speed*0.4f;
				col.GetComponent<SpriteRenderer>().color = Color.blue;
			}
		}
	}
}
