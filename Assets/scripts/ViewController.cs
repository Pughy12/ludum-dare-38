using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour {
	private string currentView;
	public GameObject[] views;

	public void changeView(string name)
	{
		Debug.Log ("@ViewController: Changing view to " + name);
		foreach (GameObject view in views)
		{
			view.SetActive (view.name == name);
		}
		currentView = name;
	}
	public string getCurrentView() {
		return currentView;
	}
}