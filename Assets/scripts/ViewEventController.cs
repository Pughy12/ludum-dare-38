using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEventController : MonoBehaviour {

	private static DistressCallEvent currentEvent;
	private GameObject ship;
	private GameObject end;

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
		Debug.Log ("Local Distance: " + localDistance);
	}

	void Update()
	{
		// If there is an event to display...
		if (currentEvent != null) {
			// Move the ship.
			float xPercent = currentEvent.getShip ().getPosition () / 100;
			xPercent *= localDistance;
			ship.transform.localPosition = new Vector3(startX + xPercent, ship.transform.localPosition.y, ship.transform.localPosition.z);
		}
		if (ViewEventController.currentEvent.getState () != DistressCallEvent.DistressCallState.IN_PROGRESS) {
			backToSearch ();
		}
	}

	void backToSearch()
	{
		ViewEventController.currentEvent = null;
		MainController.instance.viewController.getView("ViewSearch").GetComponent<ViewSearchController>().enterView();
	}

	public static void displayEvent(DistressCallEvent e)
	{
		ViewEventController.currentEvent = e;
	}
}