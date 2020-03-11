using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	private int _playerCount;
	private int _currentPlayer;

	[SerializeField]
	private GameObject[] _players;
	public GameObject player;

	public GameObject[] tiles;

	void Start() {

	}

	void Update() {

	}

	private void StartTurn() {
		_currentPlayer = (_currentPlayer % _playerCount) + 1;
		player = _players[_currentPlayer - 1];
		player.GetComponent<Player>().StartTurn();
	}

	private void EndTurn() {

	}

}
