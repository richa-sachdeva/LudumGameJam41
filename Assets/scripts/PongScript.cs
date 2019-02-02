using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// https://noobtuts.com/unity/2d-pong-game
public class PongScript : MonoBehaviour {
	private float speed = 10;
	private GameObject _manager;
	private AudioSource audioSource;
	//private bool play;

	void Start() {
		// Initial Velocity
		GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
		audioSource = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D col) {
		// Note: 'col' holds the collision information. If the
		// Ball collided with a racket, then:
		//   col.gameObject is the racket
		//   col.transform.position is the racket's position
		//   col.collider is the racket's collider
		audioSource.Play();

		// Hit the left Racket?
		if (col.gameObject.name == "Racket") {
			// Calculate hit Factor
			float x = hitFactor (transform.position.x,
				          col.transform.position.x,
				          col.collider.bounds.size.x);
			
			float y = hitFactor (transform.position.y,
				          col.transform.position.y,
				          col.collider.bounds.size.y);

			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2 (x, y).normalized;

			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D> ().velocity = dir * speed;
		} else if (col.gameObject.name == "Floor") {
			SceneManager.LoadScene ("Menu");
		}
	}

	void OnCollisionExit2D(Collision2D col) {
		audioSource.Pause ();
	}


	float hitFactor(float ballPos, float racketPos, float racketHeight) {
		// ascii art:
		// ||  1 <- at the top of the racket
		// ||
		// ||  0 <- at the middle of the racket
		// ||
		// || -1 <- at the bottom of the racket
		return (ballPos - racketPos) / racketHeight;
	}
}
