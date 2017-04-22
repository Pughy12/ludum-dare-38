using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Distress Call")]
public class DistressCallEvent : ScriptableObject {

	public int numberOfHazards;
	public Hazard[] hazards;

	public Hazard[] getHazards()
	{
		return this.hazards;
	}

	public void setHazards(Hazard[] hazards) 
	{
		this.hazards = hazards;
	}

	public int getNumberOfHazards()
	{
		return this.numberOfHazards;
	}

}
