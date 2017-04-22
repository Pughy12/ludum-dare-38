using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController {

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
	private Difficulty difficulty;

	/* Singleton Design */

	private static GameController instance;
	private GameController() {
		player = new Player ();
		difficulty = new Difficulty(20f, 0.9f, 5f);
		this.state = GameState.PROGRESS;
	}
	public static GameController getInstance()
	{
		if (instance == null) {
			instance = new GameController ();
		}
		return instance;
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