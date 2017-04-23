using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour {
	private Difficulty difficulty;

	public GameObject distressCallAlertPrefab;
	public GameObject spawnPlane;
	public GameObject spawnParent;

	public DistressCallEvent[] potentialDistressCallEvents;
	private List<DistressCallEvent> activeDistressCallEvents;
	
	void Start ()
	{
		activeDistressCallEvents = new List<DistressCallEvent>();
		difficulty = MainController.instance.gameController.getDifficulty();
		StartCoroutine ("tick");
		spawnEvent ();
	}

	void Update()
	{
		// Update all of the distress calls.
		foreach(DistressCallEvent e in activeDistressCallEvents)
		{
			if (e.getState () == DistressCallEvent.DistressCallState.IN_PROGRESS) {
				Ship s = e.getShip ();
				s.progressPosition (Time.deltaTime);
				if (s.getPosition () >= 100) {
					// Set the ship to be finished.
					e.setState (DistressCallEvent.DistressCallState.SUCCEEDED);
					// Remove it from active.
//					activeDistressCallEvents.Remove (e);
				} else {
					// Check for collisions.
					foreach (Hazard h in e.getHazards()) {
						// If not already dealt with, and within hit range...
						if (h.getState () != Hazard.HazardStatus.EVADED &&
						   h.getState () != Hazard.HazardStatus.HIT &&
						   h.checkCollision (s, DistressCallEvent.BUFFER)) {
							// Entering collision...
							if (h.rollChance ()) {
								// Check if the ship is in the correct mode.
								if (s.getMode () == Ship.ShipMode.EVASIVE && h.getHazardType () == HazardType.ASTEROID) {
									// Succeeded.
									h.setState (Hazard.HazardStatus.EVADED);
								} else if (s.getMode () == Ship.ShipMode.CLOAKING && h.getHazardType () == HazardType.ENEMY) {
									// Succeeded.
									h.setState (Hazard.HazardStatus.EVADED);
								} else {
									// Failed.
									h.setState (Hazard.HazardStatus.HIT);
									s.setLife (s.getLife () - 1);
								}
							} else {
								// Got lucky!
								h.setState (Hazard.HazardStatus.EVADED);
							}
						}
					}
					// Check for destruction.
					if (s.getLife() <= 0) {
						s.setState (Ship.ShipStatus.DESTROYED);
						e.setState (DistressCallEvent.DistressCallState.FAILED);
					}
				}
			}
		}

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
		e.getShip ().setLife (e.getShip().getStartLives());
		e.getShip ().setPosition(e.getShip().getStartPosition());
		e.setState (DistressCallEvent.DistressCallState.IN_PROGRESS);
		activeDistressCallEvents.Add (e);

		// Create the alert for it.
		GameObject clone = Instantiate(distressCallAlertPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		clone.transform.parent = spawnParent.transform;
		clone.transform.localPosition = new Vector3 (0, 0, 0);
		clone.GetComponentInChildren<DistressCallAlertController> ().init (e);
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
