using UnityEngine;

[CreateAssetMenu(menuName = "Difficulty")]
public class Difficulty : ScriptableObject {
	public float rate;
	public float multiplier;
	public float max;

	public Difficulty(float rate, float multiplier, float max)
	{
		this.rate = rate;
		this.multiplier = multiplier;
		this.max = max;
	}
}