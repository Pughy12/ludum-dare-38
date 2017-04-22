using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour {
	private Difficulty difficulty;
	public DistressCallEvent[] distressCallEvents;
	
	void Start () {
		difficulty = MainController.instance.gameController.getDifficulty ();
//		StartCoroutine ("tick");
	}

	IEnumerator tick () {
		do {
			// Wait
			yield return new WaitForSeconds (difficulty.rate);

			// Spawn event.
			spawnEvent();

			// Update timings.
			if (difficulty.rate * difficulty.multiplier > difficulty.max) {
				difficulty.rate = difficulty.max;
			} else {
				difficulty.rate = difficulty.rate * difficulty.multiplier;
			}
		} while (MainController.instance.gameController.getGameState() == GameController.GameState.PROGRESS);
		yield break;
	}

	private void spawnEvent() 
	{
//		Debug.LogFormat("Spawned event of type {0} with an actionChance of {1}",
//			hazard.getHazardType(), hazard.getActionChance());
	}
}
