using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard {

	public int actionChance;
	public HazardType hazardType;

	public Hazard()
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
