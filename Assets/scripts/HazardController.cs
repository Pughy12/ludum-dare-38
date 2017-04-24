using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour {
	private Hazard h;

	void OnMouseDown()
	{
		if (h.getState () != Hazard.HazardStatus.SCANNED) {
			// Begin scan.
			h.setState(Hazard.HazardStatus.SCANNED);
		}
		if (h.getState () == Hazard.HazardStatus.SCANNED) {
			// Display hazard.
			displayHazard();
		}
	}

	public void displayHazard()
	{
		Debug.Log ("Trying to display hazard from inside hazard.");
		GameObject.Find("ViewEvent").GetComponent<ViewEventController>().inspector.GetComponent<InspectorController>().displayHazard (this.h);
	}

	public void initialise(Hazard h)
	{
		this.h = h;
	}
}