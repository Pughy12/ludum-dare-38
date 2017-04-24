using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBackButton : MonoBehaviour {
	public GameObject parentController;
	public static float t;
	void OnMouseDown()
	{
		t = Time.time;
		parentController.GetComponent<ViewEventController> ().backToSearch ();
	}
}