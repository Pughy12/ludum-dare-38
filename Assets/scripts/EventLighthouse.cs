using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLighthouse : MonoBehaviour {
	public void transitionToSearching() {
		MainController.instance.viewController.getView("ViewSearch").GetComponent<ViewSearchController>().enterView();
	}
}