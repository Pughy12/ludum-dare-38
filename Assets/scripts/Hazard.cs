using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard {

	public enum HazardStatus
	{
		UNSCANNED,
		SCANNED,
		EVADED,
		HIT
	}
	private HazardStatus state = HazardStatus.UNSCANNED;

	public HazardType hazardType;
	public int chance = 0;
	public int scanTime = 1;
	public int position = -100;

	public bool checkCollision(Ship s, float buffer)
	{
		return Mathf.Abs (this.position - s.getPosition ()) < buffer;
	}

	public bool rollChance()
	{
		return Random.Range (0, 100) < this.chance;
	}

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

	public HazardStatus getState()
	{
		return this.state;
	}
	public void setState(HazardStatus state)
	{
		this.state = state;
	}
}