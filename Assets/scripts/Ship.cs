using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Ship")]
public class Ship : ScriptableObject {

	public bool isScanned = false;

	public enum ShipStatus
	{
		INTACT,
		DESTROYED
	}
	[System.NonSerialized]
	private ShipStatus state = ShipStatus.INTACT;

	public enum ShipMode
	{
		NONE,
		EVASIVE,
		CLOAKING
	}
	[System.NonSerialized]
	private ShipMode mode = ShipMode.NONE;

	public int startLives = 1;
	public int life = 1;
	public float speed = 5f;
	// TODO: Make these the same
	public float startPosition = 0;
	public float position = 0f;

	public float getSpeed() {
		return this.speed;
	}

	public ShipStatus getState()
	{
		return this.state;
	}
	public void setState(ShipStatus state)
	{
		this.state = state;
	}

	public ShipMode getMode()
	{
		return this.mode;
	}	
	public void setMode(ShipMode mode)
	{
		this.mode = mode;
	}

	public int getLife()
	{
		return this.life;
	}
	public void setLife(int life)
	{
		this.life = life;
	}
	public int getStartLives()
	{
		return this.startLives;
	}

	public float getStartPosition()
	{
		return this.startPosition;
	}

	public float getPosition()
	{
		return this.position;
	}
	public void setPosition(float position)
	{
		this.position = position;
	}

	public void progressPosition(float dT)
	{
		this.position += (this.speed * dT);
	}
}