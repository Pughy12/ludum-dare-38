using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSearchController : MonoBehaviour, GameView {

	private bool viewEnabled = false;

	private GameObject camera;
	private GameObject background;
	private Vector2 previousMousePosition;

	void Start () {
		// Get a reference to the camera.

		// Get a reference to the background.
		background = transform.Find("Background").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (viewEnabled) {

			Debug.Log("X: " + (Input.GetAxis ("Mouse X")));
			Debug.Log("X: " + (Input.GetAxis ("Mouse Y")));

			// Move the background based on the user's input position.

//			float dX = Input.mousePosition.x - previousMousePosition.x;
//			float dY = Input.mousePosition.y - previousMousePosition.y;
//
//			float bX = background.transform.localPosition.x; 
//			float bY = background.transform.localPosition.y;
//
//			Debug.Log ("Mouse delta: x: " + dX + ", y:" + dY);
//			Debug.Log ("Background current position: x: " + bX + ", y:" + bY);
//
//			Debug.Log ("New position:");
//			Debug.Log (bX + dX + " " + bY + dY + " " + background.transform.position.z);
//
//			background.transform.localPosition = new Vector3(bX + dX, bY + dY, background.transform.localPosition.z);
		}
//		previousMousePosition = Input.mousePosition;
	}

	// Enter the view.
	public void enterView() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		MainController.instance.viewController.changeView (this.name);
		this.viewEnabled = true;
	}
}
