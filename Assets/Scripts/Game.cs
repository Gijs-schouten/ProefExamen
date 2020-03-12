using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
	private int _playerCount;
	public int currentPlayerID;

	[SerializeField]
	private GameObject[] _players;
	public GameObject player;

	public GameObject[] tiles;

	void Start() {

	}

	void Update() {

	}

	private void StartTurn() {
		currentPlayerID = (currentPlayerID % _playerCount) + 1;
		player = _players[currentPlayerID - 1];
		//player.GetComponent<Player>().StartTurn();
	}

	private void EndTurn() {

	}

}
