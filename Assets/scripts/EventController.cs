using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour {
	private Difficulty difficulty;

	public GameObject distressCallAlertPrefab;
	public GameObject spawnPlane;
	public GameObject spawnParent;

	private float minX;
	private float maxX;
	private float minY;
	private float maxY;

	public DistressCallEvent[] potentialDistressCallEvents;
	private List<DistressCallEvent> activeDistressCallEvents;
	
	void Start ()
	{
		activeDistressCallEvents = new List<DistressCallEvent>();
		difficulty = MainController.instance.gameController.getDifficulty();

		minX = spawnPlane.transform.localPosition.x - (spawnPlane.transform.localScale.x / 2);
		maxX = spawnPlane.transform.localPosition.x + (spawnPlane.transform.localScale.x / 2);
		minY = spawnPlane.transform.localPosition.y - (spawnPlane.transform.localScale.y / 2);
		maxY = spawnPlane.transform.localPosition.y + (spawnPlane.transform.localScale.y / 2);

		StartCoroutine ("tick");

	}

	private Vector3 getRandomSpawnPosition() {
		float randomX = Random.Range (minX, maxX);
		float randomY = Random.Range (minY, maxY);
		return new Vector3 (randomX, randomY, 0);
	}

	void Update()
	{
		List<DistressCallEvent> toRemove = new List<DistressCallEvent> ();
		// Update all of the distress calls.
		if(activeDistressCallEvents.Count > 0) {
			foreach (DistressCallEvent e in activeDistressCallEvents) {
				if (e.getState () == DistressCallEvent.DistressCallState.IN_PROGRESS) {
					Ship s = e.getShip ();
					s.progressPosition (Time.deltaTime);
					if (s.getPosition () >= 100) {
						// Set the ship to be finished.
						e.setState (DistressCallEvent.DistressCallState.SUCCEEDED);
						MainController.instance.gameController.getPlayer ().setNumSuccessfulEvents(
							MainController.instance.gameController.getPlayer ().getNumSuccessfulEvents () + 1);
						// Remove it from active.
						toRemove.Add (e);
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
						if (s.getLife () <= 0) {
							s.setState (Ship.ShipStatus.DESTROYED);
							e.setState (DistressCallEvent.DistressCallState.FAILED);
							MainController.instance.gameController.getPlayer ().setNumFailedEvents(
								MainController.instance.gameController.getPlayer ().getNumFailedEvents () + 1);
						}
					}
				}
			}
		}
		// Remove removable ones.
		foreach(DistressCallEvent dce in toRemove) {
			activeDistressCallEvents.Remove (dce);
		}
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

	private Hazard[] generateRandomHazards()
	{
		Hazard[] hazards = new Hazard [Random.Range(0, 4)];
		for (int i = 0; i < hazards.Length; i++) {
			hazards [i] = new Hazard ();
			hazards [i].chance = Random.Range (15, 100);
			bool tooClose;
			do {
				hazards [i].position = Random.Range (0, 100);
				tooClose = false;
				for(int j = 0; j < hazards.Length; j++) {
					if(hazards[j] != null) {
						if((i != j) && Mathf.Abs(hazards[i].position - hazards[j].position) < 15f) {
							Debug.Log("Nah man it's too close");
							tooClose = true;
						}
					}
				}
			} while(tooClose);
			if (Random.Range (0, 10) > 5) {
				hazards [i].hazardType = HazardType.ASTEROID;
			} else {
				hazards [i].hazardType = HazardType.ENEMY;
			}
			hazards [i].setState (Hazard.HazardStatus.UNSCANNED);
		}
		return hazards;
	}

	private Ship generateRandomShip()
	{
		Ship s = new Ship ();
		s.speed = Random.Range (1, 3);
		return s;
	}

	private DistressCallEvent generateRandomDistressCallEvent()
	{
		DistressCallEvent e = new DistressCallEvent ();
		e.setShip (generateRandomShip ());
		e.setHazards (generateRandomHazards ());
		Debug.Log ("Finished generating random distress call event.");
		return e;
	}

	public void spawnEvent() 
	{
		// Add an event to the active array.
		DistressCallEvent e = generateRandomDistressCallEvent();
		e.getShip ().setLife (e.getShip().getStartLives());
		e.getShip ().setPosition(e.getShip().getStartPosition());
		e.setState (DistressCallEvent.DistressCallState.IN_PROGRESS);
		activeDistressCallEvents.Add (e);

		// Create the alert for it.
		GameObject clone = Instantiate(distressCallAlertPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		clone.transform.parent = spawnParent.transform;

		// Put it somewhere on the plane.

		clone.transform.localPosition = getRandomSpawnPosition();


		clone.GetComponentInChildren<DistressCallAlertController> ().init (e);
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
