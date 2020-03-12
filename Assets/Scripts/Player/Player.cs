using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public int currentTile;
	public bool _skipsTurn = false;
	public int addedSteps;

	[SerializeField]
	private int _playerID;

	public Dice dice;
	public PlayerMovement move;
	public Game game;


	void Start() {
		dice.DiceRoll += Move;
	}

	public void StartTurn() {
		if (_skipsTurn) {
			_skipsTurn = false;
			EndTurn();
		}

	}

	public void Move(int amount) {
		if(_playerID != game.currentPlayerID) {
			return;
		}

		move.GoToNextSpace(amount);
	}

	public void EndTurn() {

	}
}
