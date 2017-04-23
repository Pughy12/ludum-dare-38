using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEventController : MonoBehaviour {

	public GameObject hazardPrefab;

	private static DistressCallEvent currentEvent;
	private GameObject ship;
	private GameObject end;
	private List<GameObject> hazardPrefabs = new List<GameObject> ();

	public float startX;
	public float endX;
	public float localDistance;

	void Start()
	{
		// Get reference to useful elements.
		ship = transform.FindChild ("Ship").gameObject;
		startX = ship.transform.localPosition.x;
		end = transform.FindChild ("End").gameObject;
		endX = end.transform.localPosition.x;
		localDistance = Mathf.Abs(startX - endX);
	}

	void Update()
	{
		// If there is an event to display...
		if (currentEvent != null) {
			if (hazardPrefabs.Count == 0) {
				spawnHazards ();
			}
			// Move the ship.
			float xPercent = currentEvent.getShip ().getPosition () / 100;
			xPercent *= localDistance;
			ship.transform.localPosition = new Vector3(startX + xPercent, ship.transform.localPosition.y, ship.transform.localPosition.z);
		}
		// Remove view if failed.
		if (ViewEventController.currentEvent.getState () != DistressCallEvent.DistressCallState.IN_PROGRESS) {
			backToSearch ();
		}
	}

	void backToSearch()
	{
		ViewEventController.currentEvent = null;
		hazardPrefabs = new List<GameObject> ();
		MainController.instance.viewController.getView("ViewSearch").GetComponent<ViewSearchController>().enterView();
	}

	public static void displayEvent(DistressCallEvent e)
	{
		ViewEventController.currentEvent = e;
	}

	private void spawnHazards()
	{
		foreach (Hazard h in ViewEventController.currentEvent.getHazards()) {
			// Create the hazard as a prefab.
			GameObject clone = Instantiate(hazardPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			clone.transform.parent = this.transform;
			clone.transform.localPosition = new Vector3 (
				startX + localDistance * h.getPosition() / 100,
				ship.transform.localPosition.y,
				0
			);
		}
	}
}