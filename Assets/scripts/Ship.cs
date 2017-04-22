using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Ship")]
public class Ship : ScriptableObject {
	public int speed;

	public int getSpeed() {
		return this.speed;
	}
}
