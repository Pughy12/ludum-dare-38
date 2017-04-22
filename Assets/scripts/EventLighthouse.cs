using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLighthouse : MonoBehaviour {
	void OnMouseDown()
	{
		transitionToSearching ();
	}
	private void transitionToSearching() {
		MainController.instance.viewController.getView("ViewSearch").GetComponent<ViewSearchController>().enterView();
	}
}