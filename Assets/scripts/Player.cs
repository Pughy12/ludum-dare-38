using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
	private int numSuccessfulEvents;
	private int numFailedEvents;

	public Player() {
		this.numSuccessfulEvents = 0;
		this.numFailedEvents = 0;
	}

	public int getNumSuccessfulEvents()
	{
		return numSuccessfulEvents;
	}
	public void setNumSuccessfulEvents(int numSuccessfulEvents)
	{
		this.numSuccessfulEvents = numSuccessfulEvents;
	}

	public int getNumFailedEvents()
	{
		return numFailedEvents;
	}
	public void setNumFailedEvents(int numFailedEvents)
	{
		this.numFailedEvents = numFailedEvents;
	}
}