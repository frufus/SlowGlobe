using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

	private bool mouseDown = false;
	private bool rightMouseDown = false;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			mouseDown = true;
		}
		if (Input.GetMouseButtonDown(1)) {
			rightMouseDown = true;
		}

		if (Input.GetMouseButtonUp(0)) {
			mouseDown = false;
		}
		if (Input.GetMouseButtonUp(1)) {
			rightMouseDown = false;
		}

		Vector3 wm = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		GameObject hl = GameObject.Find("highlight");
		hl.transform.position = new Vector3(wm.x, wm.y, 0);

		if (mouseDown || rightMouseDown) {
			Collider2D[] hitColliders = Physics2D.OverlapCircleAll(new Vector2(wm.x, wm.y), 2);
			foreach (Collider2D col in hitColliders) {
				float mod = 0.5f;
				if (rightMouseDown) {
					mod = 1.5f;
				}

				col.GetComponent<MovementBehaviour>().speed = col.GetComponent<MovementBehaviour>().speed*mod;
				col.GetComponent<SpriteRenderer>().color = Color.blue;
			}
		}
	}
}
