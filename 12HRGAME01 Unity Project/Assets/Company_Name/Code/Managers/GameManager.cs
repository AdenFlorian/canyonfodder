using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public Transform sceneParent;

	public static GameState state = GameState.Stopped;

	public Cannon cannon;
	public Projectile projectile;

	public ScoreManager scoreManager;

	void Start ()
	{
		Instance = this;
		state = GameState.Starting;
		scoreManager = new ScoreManager();
	}

	void Update ()
	{
		DebugUI.Instance.text.text += "GameState: " + state.ToString() + "\n";
		DebugUI.Instance.text.text += "HighScore: " + scoreManager.highscore + "\n";

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (state == GameState.Ready) {
				cannon.NextState();
			} else if (state == GameState.EndOfRound) {
				Application.LoadLevel (Application.loadedLevelName);
			}
		}
	}

	public void EndRound()
	{
		projectile.Stop();
		state = GameState.EndOfRound;
	}
}

public enum GameState
{
	Stopped,
	Starting,
	MainMenu,
	Pivoting,
	Flying,
	EndOfRound,
	Ready
}
