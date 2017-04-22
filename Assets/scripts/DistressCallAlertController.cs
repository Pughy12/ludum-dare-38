using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistressCallAlertController : MonoBehaviour {
	private const string PATH_ICON = "Assets/raw/sprites/icons/";

	private DistressCallEvent e;
	private SpriteRenderer icon;

	void Start()
	{
		icon = transform.FindChild ("AlertIcon").GetComponent<SpriteRenderer> ();
	}

	public void init(DistressCallEvent e)
	{
		this.e = e;
		switch(e.getState())
		{
			case DistressCallEvent.DistressCallState.IN_PROGRESS:
				icon.sprite = Resources.Load<Sprite> (PATH_ICON + "icon-progress");
				break;
			case DistressCallEvent.DistressCallState.SUCCEEDED:
				icon.sprite = Resources.Load<Sprite> (PATH_ICON + "icon-success");
				break;
			case DistressCallEvent.DistressCallState.FAILED:
				icon.sprite = Resources.Load<Sprite> (PATH_ICON + "icon-failure");
				break;
		}
	}
}