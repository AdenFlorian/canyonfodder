using UnityEngine;
using System.Collections;

public class ScoreManager
{
	public int highscore
	{
		get; private set;
	}

	public ScoreManager()
	{
		highscore = PlayerPrefs.GetInt("highscore");
	}

	public void LogScore(int score)
	{
		if (score > highscore)
		{
			SetHighScore(score);
		}
	}

	void SetHighScore(int score)
	{
		highscore = score;
		PlayerPrefs.SetInt("highscore", score);
	}
}
