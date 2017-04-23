using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistressCallAlertController : MonoBehaviour {
	private const string PATH_ICON = "sprites/icons/";

	private DistressCallEvent e;
	private SpriteRenderer icon;

	void Update()
	{
		// TODO: Clean - camera access should be unified.
		// Check if mouse button is held down.
		if (e.getState() == DistressCallEvent.DistressCallState.IN_PROGRESS && Input.GetMouseButtonDown (0)) {
			Camera camera = GameObject.Find ("Camera").GetComponent<Camera> ();
			Vector3 cameraCenter = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, camera.nearClipPlane));
			Vector3 fwd = camera.transform.TransformDirection(Vector3.forward);

			// Check if the distress call is being clicked on.
			RaycastHit hit;
			if (Physics.Raycast(cameraCenter, fwd, out hit, 1000)) {
				if (hit.transform.gameObject == this.gameObject) {
					transitionToDistressCall ();
				}
			}
		}
		if (icon && e) {
			switch (e.getState ()) {
				case DistressCallEvent.DistressCallState.IN_PROGRESS:
					icon.sprite = Resources.Load<Sprite> (PATH_ICON + "icon-event-progress");
					break;
				case DistressCallEvent.DistressCallState.SUCCEEDED:
					icon.sprite = Resources.Load<Sprite> (PATH_ICON + "icon-event-success");
					break;
				case DistressCallEvent.DistressCallState.FAILED:
					icon.sprite = Resources.Load<Sprite> (PATH_ICON + "icon-event-failure");
					break;
			}
		}
	}
		
	private void transitionToDistressCall()
	{
		ViewEventController.displayEvent (this.e);
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		MainController.instance.viewController.changeView ("ViewEvent");
	}

	public void init(DistressCallEvent e)
	{
		icon = transform.GetComponent<SpriteRenderer> ();
		this.e = e;
	}
}