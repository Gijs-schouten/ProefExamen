using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public int currentTile;
	public bool _skipsTurn = false;
	public int addedSteps;

	public Dice dice;


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

		

		//walk(dice)


	}

	public void EndTurn() {

	}
}
