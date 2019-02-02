using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour {
	public float speed = 15;

	void FixedUpdate () {
		float v = Input.GetAxisRaw("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0.0f) * speed;
	}
}
