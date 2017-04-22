using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Distress Call")]
public class DistressCallEvent : ScriptableObject {

	public enum DistressCallState {
		UNCALLED,
		IN_PROGRESS,
		SUCCEEDED,
		FAILED
	}
	private DistressCallState state = DistressCallState.UNCALLED;

	public int length = 100;

	public Ship ship;
	public Hazard[] hazards;

	public Hazard[] getHazards()
	{
		return this.hazards;
	}

	public void setHazards(Hazard[] hazards) 
	{
		this.hazards = hazards;
		this.numberOfHazards = hazards.GetLength ();
	}
	public int getLength() {
		return this.length;
	}
	public DistressCallState getState() {
		return this.state;
	}
	public void setState(DistressCallState state) {
		this.state = state;
	}
}
