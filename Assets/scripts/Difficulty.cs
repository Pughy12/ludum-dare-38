[System.Serializable]
public class Difficulty {
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