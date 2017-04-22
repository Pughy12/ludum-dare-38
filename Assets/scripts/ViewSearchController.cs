using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSearchController : MonoBehaviour, GameView {

	private bool viewEnabled = false;

	private Camera camera;
	private GameObject b;
	private float bXScale;
	private float bYScale;

	private Vector3 nPCenter;

	void Start () {
		// Get a reference to the camera.
		camera = GameObject.Find("Camera").GetComponent<Camera>();
		// Get a reference to the background.
		b = transform.Find("Background").gameObject;
		// TODO: Get the size based on the sprite.
		bXScale = 60;
		bYScale = 40;
	}
	
	// Update is called once per frame
	void Update () {
		if (viewEnabled) {
			
			// Move the background based on the user's input position.
			float dX = Input.GetAxis ("Mouse X");
			float dY = Input.GetAxis ("Mouse Y");

			// If there have been changes, move screen.
			if (!(dX == 0 && dY == 0)) {
				float bX = b.transform.localPosition.x; 
				float bY = b.transform.localPosition.y;

				nPCenter = new Vector3 (bX + dX, bY + dY, b.transform.localPosition.z);

				float nPTop = nPCenter.y + bYScale / 2;
				float nPRight = nPCenter.x + bXScale / 2;
				float nPBottom = nPCenter.y - bYScale / 2;
				float nPLeft = nPCenter.x - bXScale / 2;

				// Clamp this to the bounds of the camera.
				Vector3 nWPTop = camera.WorldToViewportPoint (new Vector3 (0, nPTop, 0));
				Vector3 nWPRight = camera.WorldToViewportPoint (new Vector3 (nPRight, 0, 0));
				Vector3 nWPBottom = camera.WorldToViewportPoint (new Vector3 (0, nPBottom, 0));
				Vector3 nWPLeft = camera.WorldToViewportPoint (new Vector3 (nPLeft, 0, 0));

				if (nWPTop.y < 1 || nWPBottom.y > 0) {
					nPCenter.y = bY;
				}
				if (nWPLeft.x > 0 || nWPRight.x < 1) {
					nPCenter.x = bX;
				}
			}
			if (nPCenter != null) {
				b.transform.localPosition = Vector3.Lerp (b.transform.localPosition, nPCenter, 0.1f);
			}
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
