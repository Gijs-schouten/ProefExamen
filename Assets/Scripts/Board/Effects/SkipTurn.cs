using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTurn : MonoBehaviour {
	public Game game;

	private void Skip(GameObject player) {
		game.player.GetComponent<Player>()._skipsTurn = true;
	}
}
