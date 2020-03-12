using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	[SerializeField]
	private int _steps;

	[SerializeField]
	private Game game;

	private void AddSteps() {
		game.player.GetComponent<Player>().addedSteps = _steps;
	}
}
