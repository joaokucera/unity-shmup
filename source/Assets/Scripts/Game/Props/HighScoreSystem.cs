using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

/// <summary>
/// A script to load and save players's points.
/// </summary>
public class HighScoreSystem : BaseScript 
{
	#region [ FIELDS ]
	
	/// <summary>
	/// The highscore key.
	/// </summary>
	private const string HighScoreKey = "HIGHSCORES";
	
	/// <summary>
	/// The instance.
	/// </summary>
	private static HighScoreSystem instance;
	
	/// <summary>
	/// The scores.
	/// </summary>
	private List<PlayerScore> scores = new List<PlayerScore>();
	
	#endregion
	
	#region [ PROPERTIES ]
	
	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static HighScoreSystem Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<HighScoreSystem>();
			}
			
			return instance;
		}
	}
	
	/// <summary>
	/// Gets or sets the scores.
	/// </summary>
	/// <value>The scores.</value>
	public List<PlayerScore> Scores 
	{
		get
		{
			if (scores == null)
			{
				scores = new List<PlayerScore>();
			}

			return scores;
		}
	}

	/// <summary>
	/// Gets or sets the highest score.
	/// </summary>
	/// <value>The highest score.</value>
	public int HighestScore 
	{
		get
		{
			int max = 0;

			if (Scores != null && Scores.Count > 0)
			{
				max = Scores.Max(s => s.Score);
			}

			return max;
		}
	}
	
	#endregion
	
	#region [ METHODS ]
	
	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this);
			
			LoadScores ();
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	/// <summary>
	/// Loads the scores.
	/// </summary>
	private void LoadScores ()
	{
		string[] highscoresArray = PlayerPrefsX.GetStringArray (HighScoreKey);
		List<string[]> highscoresList = highscoresArray.Select (h => h.Split (new char[] { '|' })).ToList();

		scores.Clear ();
		highscoresList.ForEach (h => 
		{
			scores.Add(new PlayerScore
			{
				Name = h[0],
				Score = Convert.ToInt32(h[1])
			});
		});

		scores = scores.OrderByDescending(s => s.Score).ToList ();
	}
	
	/// <summary>
	/// Saves the scores.
	/// </summary>
	private void SaveScores ()
	{
		scores = scores.OrderByDescending(s => s.Score).ToList ();
		string[] array = scores.Select (s => s.Data).ToArray ();

		PlayerPrefsX.SetStringArray (HighScoreKey, array);
	}
	
	/// <summary>
	/// Adds the new score.
	/// </summary>
	/// <param name="playerName">Player name.</param>
	/// <param name="currentScore">Current score.</param>
	public void AddNewScore (string playerName, int currentScore)
	{
		scores.Add (new PlayerScore 
		{
			Name = playerName,
			Score = currentScore
		});
	
		SaveScores ();
	}
	
	#endregion
}