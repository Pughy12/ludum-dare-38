[System.Serializable]
/// <summary>
/// Adjust game difficulty.
/// </summary>
public class Difficulty {
	
	/// <summary>
	/// The rate at which events will fire.
	/// </summary>
	public int rate;

	/// <summary>
	/// The value to multiply the rate with each time.
	/// </summary>
	public int multiplier;

	/// <summary>
	/// The cap on the rate value.
	/// </summary>
	public int max;
}