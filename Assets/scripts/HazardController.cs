using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour {
	private Hazard h;

	void OnMouseDown()
	{
		if (h.getState () == Hazard.HazardStatus.UNSCANNED) {
			// Begin scan.
			h.setState(Hazard.HazardStatus.SCANNED);
		}
		if (h.getState () == Hazard.HazardStatus.SCANNED) {
			// Dislpay hazard.
			displayHazard();
		}
	}

	public void displayHazard()
	{

	}

	public void update()
	{
		
	}
	public void initialise(Hazard h)
	{
		this.h = h;
	}
}