using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//https://www.youtube.com/watch?v=prfzIpNhQMM
public class Card : MonoBehaviour {

	public static bool DO_NOT = false;

	private int _state;
	public int _cardValue;
	private bool _initialized = false;

	public Sprite _cardBack;
	public Sprite _cardFace;

	private GameObject _manager;
	// Use this for initialization
	void Start () {
		_state = 0;
		_manager = GameObject.FindGameObjectWithTag ("Manager");
		this.GetComponent<SpriteRenderer> ().sprite = _cardBack;
		_initialized = true;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "Ball") {
			flipCard ();
			_manager.GetComponent<GameManager> ().checkCards ();
		}
	}

	public void flipCard() {
		if (_state == 0) {
			_state = 1;
		} else if (_state == 1) {
			_state = 0;
		}
		if (_state == 0 && !DO_NOT) {
			GetComponent<SpriteRenderer> ().sprite = _cardBack;
		} else if (_state == 1 && !DO_NOT) {
			GetComponent<SpriteRenderer> ().sprite = _cardFace;
		}
	}

	public int cardValue {
		get { return _cardValue; }
		set { _cardValue = value; }
	}

	public int state {
		get { return _state; }
		set { _state = value; }
	}

	public bool initialized {
		get { return _initialized; }
		set { _initialized = value; }
	}

	public void falseCheck() {
		StartCoroutine (pause ());
	}

	IEnumerator pause() {
		yield return new WaitForSeconds (1);
		if (_state == 0) {
			GetComponent<SpriteRenderer> ().sprite = _cardBack;
		} else if (_state == 1) {
			GetComponent<SpriteRenderer> ().sprite = _cardFace;
		}
		DO_NOT = false;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
