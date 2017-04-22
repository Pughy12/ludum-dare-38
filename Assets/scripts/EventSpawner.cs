using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSpawner : MonoBehaviour {
	private Difficulty difficulty;
	
	void Start () {
		difficulty = GameController.getInstance ().getDifficulty ();
		StartCoroutine ("tick");
	}

	IEnumerator tick () {
		do {
			// Wait
			yield return new WaitForSeconds (difficulty.getRate());

			// Spawn event.
			HazardEvent hazard = new HazardEvent();
			Debug.LogFormat("Spawned event of type {0} with an actionChance of {1}",
				hazard.getHazardType(), hazard.getActionChance());

			// Update timings.
			if (difficulty.getRate() * difficulty.getMultiplier() > difficulty.getMax()) {
				difficulty.setRate(difficulty.getMax());
			} else {
				difficulty.setRate(difficulty.getRate() * difficulty.getMultiplier());
			}
		} while (GameController.getInstance().getGameState() == GameController.GameState.PROGRESS);
		yield break;
	}
}
