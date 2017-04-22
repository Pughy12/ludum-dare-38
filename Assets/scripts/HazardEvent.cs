using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardEvent {

	private int actionChance;
	private HazardType hazardType;

	public HazardEvent()
	{
		// Random chance that the player will have to action this hazard
		this.actionChance = Random.Range (0, 100);

		// For now, all hazards are the same. This will be different later though.
		this.hazardType = HazardType.ASTEROID;
	}

	// Getters
	public int getActionChance()
	{
		return this.actionChance;
	}

	public HazardType getHazardType()
	{
		return this.hazardType;
	}



	

}
