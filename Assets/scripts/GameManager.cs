using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject[] cards;
	public Text matchText;

	private bool _init = false;
	private int _matches = 12;

	private Vector3 farOff = new Vector3 (-500, -500, 0);

	void Start() {
		Card.DO_NOT = false;
		for (int i = 0; i < cards.Length; i++) {
			cards [i].GetComponent<Card> ().state = 0;
			cards [i].GetComponent<Card> ().initialized = true;
		}
	}

	public void checkCards() {
		List<int> c = new List<int> ();

		for (int i = 0; i < cards.Length; i++) {
			if (cards [i].GetComponent<Card> ().state == 1) {
				c.Add (i);
			}
		}
			
		if (c.Count == 2) {
			cardComparison (c);
		} else if (c.Count > 2) {
			for (int i = 0; i < c.Count; i++) {
				cards [c [i]].GetComponent<Card> ().state = 0;
				cards [c [i]].GetComponent<Card> ().falseCheck ();
			}
		}
	}

	void cardComparison(List<int> c) {
		Card.DO_NOT = true;

		int x = 0;
		if (cards [c [0]].GetComponent<Card> ().cardValue == cards [c [1]].GetComponent<Card> ().cardValue) {
			x = 2;
			_matches--;
			cards [c [0]].GetComponent<Card> ().transform.position = farOff;
			cards [c [1]].GetComponent<Card> ().transform.position = farOff;

			matchText.text = "Matches left: " + _matches;
			if (_matches == 0 ) {
				SceneManager.LoadScene ("Menu");
			}
		}

		for (int i = 0; i < c.Count; i++) {
			cards [c [i]].GetComponent<Card> ().state = x;
			cards [c [i]].GetComponent<Card> ().falseCheck ();
		}
	}
}
