using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {
	public static GameController getInstance()
	{
		if (instance == null) {
			instance = new GameController ();
		}
		return instance;
	}

	void Start () {
		// Change view.
		vc.changeView("ViewRoot");
	}
}
