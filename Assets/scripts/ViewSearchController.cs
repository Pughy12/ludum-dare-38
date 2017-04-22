using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSearchController : MonoBehaviour, GameView {

	private bool viewEnabled = false;

	private Camera camera;
	private GameObject b;
	private float bXScale;
	private float bYScale;

	void Start () {
		// Get a reference to the camera.
		camera = GameObject.Find("Camera").GetComponent<Camera>();
		// Get a reference to the background.
		b = transform.Find("Background").gameObject;
		bXScale = b.transform.localScale.x;
		bYScale = b.transform.localScale.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (viewEnabled) {
			
			// Move the background based on the user's input position.
			float dX = Input.GetAxis ("Mouse X");
			float dY = Input.GetAxis ("Mouse Y");

			// If there have been no changes, don't move screen.
			if (dX == 0 && dY == 0) {
				return;
			}

			float bX = b.transform.localPosition.x; 
			float bY = b.transform.localPosition.y;

			// Clamp this to the bounds of the camera.
			Vector3 vP = camera.WorldToViewportPoint (b.transform.TransformPoint(new Vector3 (bX, bY, b.transform.localPosition.z)));
			Debug.Log ("x: " + vP.x + ", y: " + vP.y + ", z: " + vP.z);


			b.transform.localPosition = new Vector3(bX + dX, bY + dY, b.transform.localPosition.z);
		}
	}

	// Enter the view.
	public void enterView() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		MainController.instance.viewController.changeView (this.name);
		this.viewEnabled = true;
	}
}
