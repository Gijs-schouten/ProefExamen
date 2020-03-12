using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public int currentTile;
	public bool _skipsTurn = false;

	void Start() {

	}

	// Update is called once per frame
	void Update() {
		
	}

	public void StartTurn() {
		if (_skipsTurn) {
			_skipsTurn = false;
			EndTurn();
		}
	}

	public void EndTurn() {

	}
}
