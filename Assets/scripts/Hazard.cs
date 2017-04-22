using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hazard {

	public HazardType hazardType;
	public int chance;
	public int scanTime;
	public int position;

	/* Accessor Methods */

	public HazardType getHazardType()
	{
		return this.hazardType;
	}

	public int getChance()
	{
		return this.chance;
	}

	public int getScanTime()
	{
		return this.scanTime;
	}

	public int getPosition()
	{
		return this.position;
	}
}
