using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour {
	public event Action<int> DiceRoll;

	public void RollDice() {
		DiceRoll?.Invoke(UnityEngine.Random.Range(1, 12));
	}

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            RollDice();
        }
    }
}
