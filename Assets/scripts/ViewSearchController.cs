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
//		bXScale = b.transform.localScale.x;
//		bYScale = b.transform.localScale.y;
		bXScale = 60;
		bYScale = 40;
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

			Vector3 nPCenter = new Vector3(bX + dX, bY + dY, b.transform.localPosition.z);

			Vector3 nPTopLeft = new Vector3(nPCenter.x - bXScale / 2, nPCenter.y - bYScale / 2, nPCenter.z);
			Vector3 nPTopRight = new Vector3(nPCenter.x + bXScale / 2, nPCenter.y - bYScale / 2, nPCenter.z);
			Vector3 nPBottomLeft = new Vector3(nPCenter.x - bXScale / 2, nPCenter.y + bYScale / 2, nPCenter.z);
			Vector3 nPBottomRight = new Vector3(nPCenter.x + bXScale / 2, nPCenter.y + bYScale / 2, nPCenter.z);

			// Clamp this to the bounds of the camera.
			Vector3 nVPTopLeft = camera.WorldToViewportPoint(b.transform.TransformPoint(nPTopLeft));
			Vector3 nVPTopRight = camera.WorldToViewportPoint(b.transform.TransformPoint(nPTopRight));
			Vector3 nVPBottomLeft = camera.WorldToViewportPoint(b.transform.TransformPoint(nPBottomLeft));
			Vector3 nVPBottomRight = camera.WorldToViewportPoint(b.transform.TransformPoint(nPBottomRight));

			if (nVPTopLeft.x > 0 && nVPTopLeft.x < 1 && nVPTopLeft.y > 0 && nVPTopLeft.y < 1) {
				Debug.Log ("Top left corner is in view!");
			}

//			Debug.Log (worldPoint.x + " " + worldPoint.y + " " + worldPoint.z);

			Vector3 vP = camera.WorldToViewportPoint (nPCenter);
//			Debug.Log ("x: " + vP.x + ", y: " + vP.y + ", z: " + vP.z);

			b.transform.localPosition = nPCenter;
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
