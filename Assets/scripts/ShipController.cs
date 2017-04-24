using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {
	public GameObject shipModeText;
	
	void OnMouseDown()
	{
		if (ViewEventController.currentEvent.getShip ().getMode () == Ship.ShipMode.NONE) {
			ViewEventController.currentEvent.getShip ().setMode (Ship.ShipMode.EVASIVE);
			shipModeText.GetComponent<Text> ().text = "EVASIVE";
		} else if (ViewEventController.currentEvent.getShip ().getMode () == Ship.ShipMode.EVASIVE) {
			ViewEventController.currentEvent.getShip ().setMode (Ship.ShipMode.CLOAKING);
			shipModeText.GetComponent<Text> ().text = "CLOAKING";
		} else if (ViewEventController.currentEvent.getShip ().getMode () == Ship.ShipMode.CLOAKING) {
			ViewEventController.currentEvent.getShip ().setMode (Ship.ShipMode.NONE);
			shipModeText.GetComponent<Text> ().text = "NONE";
		}
	}
}
