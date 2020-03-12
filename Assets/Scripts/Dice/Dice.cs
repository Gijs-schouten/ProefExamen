using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {
	
	public int RollDice() {
		return Random.Range(1, 12);
	}
}
