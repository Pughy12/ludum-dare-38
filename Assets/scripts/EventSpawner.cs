using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSpawner : MonoBehaviour {
	private Difficulty difficulty;

	// Use this for initialization
	void Start () {
		StartCoroutine ("tick");
	}

	IEnumerator tick () {
		do {
			yield return new WaitForSeconds (3.0f);
			Debug.Log ("Tick");
		} while (GameController.getInstance().getGameState() == GameController.GameState.PROGRESS);
		yield break;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
