using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using System;

/// <summary>
/// Controls all UI elements.
/// </summary>
public class HUDControl : BaseScript 
{
	#region [ FIELDS ]

	/// <summary>
	/// The life group.
	/// </summary>
	[SerializeField]
	private Transform lifeGroup;
	/// <summary>
	/// The life icon prefab.
	/// </summary>
	[SerializeField]
	private GameObject lifeIconPrefab;
	/// <summary>
	/// The lives icons.
	/// </summary>
	private List<GameObject> lifeIconList = new List<GameObject> ();
	/// <summary>
	/// The score text U.
	/// </summary>
	[SerializeField]
	private Text scoreTextUI;
	/// <summary>
	/// The score.
	/// </summary>
	private int currentScore = 0;
	/// <summary>
	/// The high score text U.
	/// </summary>
	[SerializeField]
	private Text highScoreTextUI;
	/// <summary>
	/// The high score.
	/// </summary>
	private int highScore;
	/// <summary>
	/// The ready text U.
	/// </summary>
	[SerializeField]
	private Text readyTextUI;
	/// <summary>
	/// The stage text U.
	/// </summary>
	[SerializeField]
	private Text stageTextUI;
	/// <summary>
	/// The stage.
	/// </summary>
	private int stage = 1;
	/// <summary>
	/// The game over image U.
	/// </summary>
	[SerializeField]
	private Image gameOverImageUI;
	/// <summary>
	/// The game over animator.
	/// </summary>
	[SerializeField]
	private Animator gameOverAnimator;
	/// <summary>
	/// The player name field U.
	/// </summary>
	[SerializeField]
	private InputField playerNameFieldUI;
	/// <summary>
	/// Your score text U.
	/// </summary>
	[SerializeField]
	private Text yourScoreTextUI;
	/// <summary>
	/// The best score text U.
	/// </summary>
	[SerializeField]
	private Text bestScoreTextUI;
	/// <summary>
	/// The gun icon image U.
	/// </summary>
	[SerializeField]
	private Image gunIconImageUI;
	/// <summary>
	/// The original gun icon sprite.
	/// </summary>
	private Sprite originalGunIconSprite;

	#endregion

	#region [ PROPERTIES ]

	/// <summary>
	/// Gets the score.
	/// </summary>
	/// <value>The score.</value>
	public int Score 
	{
		get { return currentScore; }
	}

	/// <summary>
	/// Sets the high score.
	/// </summary>
	/// <value>The high score.</value>
	public int HighScore 
	{
		get { return highScore; }
		set { highScore = value; }
	}

	/// <summary>
	/// Gets the stage.
	/// </summary>
	/// <value>The stage.</value>
	public int Stage 
	{
		get { return stage; }
	}

	#endregion

	#region [ METHODS ]

	protected override void Start ()
	{
		if (gameOverImageUI == null)
		{
			Debug.LogError("The game over image panel was not set!");
		}
		gameOverImageUI.enabled = false;

		if (gameOverAnimator == null)
		{
			Debug.LogError("The game over animator was not set!");
		}
		gameOverAnimator.enabled = false;

		if (gunIconImageUI == null)
		{
			Debug.LogError("The gun icon image was not set!");
		}
		originalGunIconSprite = gunIconImageUI.sprite;

		if (playerNameFieldUI == null)
		{
			Debug.LogError("The player name field was not set!");
		}

		highScore = HighScoreSystem.Instance.HighestScore;
		highScoreTextUI.text = highScore.ToString ();
	}

	/// <summary>
	/// Starts the lives.
	/// </summary>
	/// <param name="lives">Lives.</param>
	public void StartLives (int lives)
	{
		for (int i = 0; i < PlayerHealth.PlayerMaxLives; i++) 
		{
			GameObject lifeIcon = Instantiate(lifeIconPrefab) as GameObject;

			lives--;
			if (lives < 0)
			{
				lifeIcon.SetActive(false);
			}

			lifeIcon.transform.SetParent(lifeGroup);

			lifeIconList.Add(lifeIcon);
		}
	}

	/// <summary>
	/// Activates the life icon.
	/// </summary>
	public void ActivateLifeIcon ()
	{
		GameObject first = lifeIconList.FirstOrDefault (i => !i.activeInHierarchy);

		if (first != null) 
		{
			first.SetActive(true);
		}
	}

	/// <summary>
	/// Deactivates the life icon.
	/// </summary>
	public void DeactivateLifeIcon ()
	{
		GameObject first = lifeIconList.FirstOrDefault (i => i.activeInHierarchy);
		
		if (first != null) 
		{
			first.SetActive(false);
		}
	}

	/// <summary>
	/// Adds the points.
	/// </summary>
	/// <param name="points">Points.</param>
	public void AddPoints (int points)
	{
		currentScore += points;
		scoreTextUI.text = currentScore.ToString ();

		if (currentScore > highScore)
		{
			highScore = currentScore;
			highScoreTextUI.text = highScore.ToString ();
		}
	}

	/// <summary>
	/// Starts the level.
	/// </summary>
	public void StartStage ()
	{
		stageTextUI.enabled = false;
		readyTextUI.enabled = false;
	}

	/// <summary>
	/// Stages the completed.
	/// </summary>
	public void StageCompleted ()
	{
		stageTextUI.text = string.Format ("STAGE {0} COMPLETED", stage);
		stageTextUI.enabled = true;

		BackToOriginalGun ();
	}

	/// <summary>
	/// Deactivates the stage text.
	/// </summary>
	public void DeactivateStageText()
	{
		stageTextUI.text = string.Empty;
		stageTextUI.enabled = false;
	}

	/// <summary>
	/// Starts the level.
	/// </summary>
	public void NextStage ()
	{
		stage++;
		stageTextUI.text = "STAGE " + stage;
		stageTextUI.enabled = true;
		
		readyTextUI.enabled = true;
	}

	/// <summary>
	/// Actives the game over.
	/// </summary>
	public void ActiveGameOver ()
	{
		readyTextUI.enabled = false;	
		stageTextUI.enabled = false;

		yourScoreTextUI.text = string.Format ("YOUR SCORE{0}{1}", Environment.NewLine, currentScore);
		bestScoreTextUI.text = string.Format ("BEST SCORE{0}{1}", Environment.NewLine, highScore);

		StartCoroutine (ShowGameOverPanel());

		gameOverAnimator.enabled = true;
	}

	/// <summary>
	/// Shows the game over panel.
	/// </summary>
	/// <returns>The game over panel.</returns>
	private IEnumerator ShowGameOverPanel()
	{
		gameOverImageUI.enabled = true;

		float alpha = 192f / 255f;
		Color gameOverColor = gameOverImageUI.color;

		while (gameOverColor.a < alpha)
		{
			gameOverColor.a += Time.deltaTime;
			gameOverImageUI.color = gameOverColor;

			yield return 0;
		}
	}

	/// <summary>
	/// Saves the new player score.
	/// </summary>
	public void SaveNewPlayerScore ()
	{
		string playerName = !string.IsNullOrEmpty (playerNameFieldUI.text) ? playerNameFieldUI.text : "<NULL>";

		HighScoreSystem.Instance.AddNewScore (playerName, currentScore);
	}

	/// <summary>
	/// Changes the gun icon sprite.
	/// </summary>
	/// <param name="gunSprite">Gun sprite.</param>
	public void ImproveGun(Sprite gunSprite)
	{
		gunIconImageUI.sprite = gunSprite;
	}
	
	/// <summary>
	/// Backs to original gun.
	/// </summary>
	private void BackToOriginalGun()
	{
		gunIconImageUI.sprite = originalGunIconSprite;

		GlobalVariables.PlayerWeapon.ActivateGuns(new PlayerGun[] { PlayerGun.Front });
	}

	#endregion
}