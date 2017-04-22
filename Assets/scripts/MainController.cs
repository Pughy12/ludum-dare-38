using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	// Singleton Design Pattern
	public static MainController instance = null;
	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
	}

	// Controller management.
	public ViewController viewController;
	public GameController gameController;
	public EventController eventController;

	// Main method - begin game.
	void Start () {
		// Change view.
		viewController.changeView("ViewSearch");
	}
}
