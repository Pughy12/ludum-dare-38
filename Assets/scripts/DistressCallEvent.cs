using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistressCallEvent {

	private Difficulty difficulty;
	private HazardEvent[] hazards;

	// Getters
	public Difficulty getDifficulty() 
	{
		return this.difficulty;
	}

	public HazardEvent[] getHazards()
	{
		return this.hazards;
	}

	// Setters
	public void setDifficulty(Difficulty difficulty) 
	{
		this.difficulty = difficulty;
	}

	public void setHazards(HazardEvent[] hazards)
	{
		this.hazards = hazards;
	}

}
