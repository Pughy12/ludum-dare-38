using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour {
	private Difficulty difficulty;
	
	void Start () {
		difficulty = MainController.instance.gameController.getDifficulty ();
		StartCoroutine ("tick");
	}

	IEnumerator tick () {
		do {
			// Wait
			yield return new WaitForSeconds (difficulty.getRate());

			// Spawn event.
			spawnEvent();

			// Update timings.
			if (difficulty.getRate() * difficulty.getMultiplier() > difficulty.getMax()) {
				difficulty.setRate(difficulty.getMax());
			} else {
				difficulty.setRate(difficulty.getRate() * difficulty.getMultiplier());
			}
		} while (MainController.instance.gameController.getGameState() == GameController.GameState.PROGRESS);
		yield break;
	}

	private void spawnEvent() 
	{
		Debug.Log("Spawning event.");
	}
}
