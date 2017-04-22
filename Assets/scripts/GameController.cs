using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	/* Managed Fields */

	// State
	public enum GameState {
		SETUP,
		PROGRESS,
		FINISHED
	};
	private GameState state = GameState.SETUP;

	// Player
	private Player player;

	// Difficulty
	public Difficulty difficulty;

	/* Run */
	void Start() {
		player = new Player ();
		this.state = GameState.PROGRESS;
	}

	/* Accessor Methods */

	public Player getPlayer()
	{
		return this.player;
	}
	public Difficulty getDifficulty()
	{
		return this.difficulty;
	}
	public GameState getGameState()
	{
		return this.state;
	}
}