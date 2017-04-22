using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistressCallAlertController : MonoBehaviour {
	private const string PATH_ICON = "sprites/icons/";

	private DistressCallEvent e;
	private SpriteRenderer icon;

	public void init(DistressCallEvent e)
	{
		icon = transform.FindChild ("AlertIcon").GetComponent<SpriteRenderer> ();
		this.e = e;
		switch(e.getState())
		{
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
		Debug.Log (icon.sprite);
	}

	
}