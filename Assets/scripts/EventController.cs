using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour {
	private Difficulty difficulty;

	public GameObject distressCallAlertPrefab;
	public GameObject spawnPlane;
	public GameObject spawnParent;

	public DistressCallEvent[] potentialDistressCallEvents;
	private List<DistressCallEvent> activeDistressCallEvents = new List<DistressCallEvent>();
	
	void Start () {
		difficulty = MainController.instance.gameController.getDifficulty();
		StartCoroutine ("tick");
	}

	IEnumerator tick () {
		do {
			// Wait
			yield return new WaitForSeconds (difficulty.rate);

			// Spawn event.
//			spawnEvent();

			// Update timings.
			if (difficulty.rate * difficulty.multiplier > difficulty.max) {
				difficulty.rate = difficulty.max;
			} else {
				difficulty.rate = difficulty.rate * difficulty.multiplier;
			}
		} while (MainController.instance.gameController.getGameState() == GameController.GameState.PROGRESS);
		yield break;
	}

	public void spawnEvent() 
	{
		// Add an event to the active array.
		DistressCallEvent e = potentialDistressCallEvents [0];
		e.setState (DistressCallEvent.DistressCallState.IN_PROGRESS);
		activeDistressCallEvents.Add (e);
		// Create the alert for it.
		GameObject clone = Instantiate(distressCallAlertPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		clone.transform.parent = spawnParent.transform;
		clone.transform.localPosition = new Vector3 (0, 0, 0);
		clone.GetComponent<DistressCallAlertController> ().init (e);
		// TODO: Co-ordinates.
	}

	private Hazard[] generateHazards(int num)
	{
		Hazard[] eventHazards = new Hazard[num];

		for (int i = 0; i < num; i++)
		{
			eventHazards [i] = new Hazard ();
		}

		return eventHazards;
	}
}
