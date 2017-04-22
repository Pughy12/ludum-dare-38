public class Difficulty {
	private float rate;
	private float multiplier;
	private float max;

	public Difficulty(float rate, float multiplier, float max)
	{
		this.rate = rate;
		this.multiplier = multiplier;
		this.max = max;
	}

	public float getRate()
	{
		return this.rate;
	}
	public void setRate(float rate)
	{
		this.rate = rate;
	}

	public float getMultiplier()
	{
		return this.multiplier;
	}
	public void setMultiplier(float multiplier)
	{
		this.multiplier = multiplier;
	}

	public float getMax()
	{
		return this.max;
	}
	public void setMax(float max)
	{
		this.max = max;
	}
}