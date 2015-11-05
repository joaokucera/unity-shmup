using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The main script who controls game's stages.
/// </summary>
public class LevelControl : BaseScript 
{
	#region [ FIELDS ]

	/// <summary>
	/// The time to next stage.
	/// </summary>
	[SerializeField]
	private float timeToNextStage = 60f;
	/// <summary>
	/// The stage timer.
	/// </summary>
	private float stageTimer;
	/// <summary>
	/// The time to spawn.
	/// </summary>
	[SerializeField]
	private float minTimeToSpawn = 3f;
	/// <summary>
	/// The max time to spawn.
	/// </summary>
	[SerializeField]
	private float maxTimeToSpawn = 5f;
	/// <summary>
	/// The value to decrement from time to spawn.
	/// </summary>
	[SerializeField]
	private float valueToDecrementFromTimeToSpawn = 0.25f;
	/// <summary>
	/// The spawn timer.
	/// </summary>
	private float spawnTimer;
	/// <summary>
	/// The start player position.
	/// </summary>
	private Vector2 startPlayerPosition;
	/// <summary>
	/// The state.
	/// </summary>
	private LevelState currentState = LevelState.Begin;

	#endregion

	#region [ PROPERTIES ]

	/// <summary>
	/// Gets or sets the state.
	/// </summary>
	/// <value>The state.</value>
	public LevelState State
	{
		get 
		{ 
			return currentState; 
		}
		set
		{
			if (currentState == value)
			{
				return;
			}

			currentState = value;

			switch (currentState) 
			{
				case LevelState.Begin:
				{
					StartCoroutine (OnBegin ());
					break;
				}
				case LevelState.Playing:
				{	
					StartCoroutine (OnPlaying ());
					break;
				}
				case LevelState.Interlude:
				{
					StartCoroutine (OnInterlude ());
					break;
				}
				case LevelState.GameOver:
				{
					OnGameOver ();
					break;
				}
			}
		}
	}

	#endregion

	#region [ METHODS ]

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		startPlayerPosition = GlobalVariables.PlayerObject.transform.position;

		ActiveScripts (false);

		stageTimer = timeToNextStage;
		spawnTimer = Random.Range (minTimeToSpawn, maxTimeToSpawn);

		currentState = LevelState.Begin;
		StartCoroutine (OnBegin ());
	}

	/// <summary>
	/// Raises the begin event.
	/// </summary>
	private IEnumerator OnBegin()
	{
		while ((GlobalVariables.PlayerObject.transform.position.y + GlobalVariables.PlayerObject.renderer.bounds.size.y / 2) < -GlobalVariables.WorldSize.y / 2)
		{
			yield return 0;
		}

		ActiveScripts (true);
		GlobalVariables.HUDControl.StartStage();
		
		State = LevelState.Playing;
	}

	/// <summary>
	/// Raises the playing event.
	/// </summary>
	private IEnumerator OnPlaying()
	{
		GlobalVariables.PlayerObject.collider2D.enabled = true;

		while (stageTimer > 0)
		{
			spawnTimer -= Time.deltaTime;
			if (spawnTimer < 0)
			{
				spawnTimer = Random.Range (minTimeToSpawn, maxTimeToSpawn);
				GlobalVariables.EnemySpawner.Spawn();
			}

			stageTimer -= Time.deltaTime;
			yield return 0;
		}

		stageTimer = timeToNextStage;
		minTimeToSpawn -= valueToDecrementFromTimeToSpawn;
		maxTimeToSpawn -= valueToDecrementFromTimeToSpawn;

		ActiveScripts (false);
		SoundEffectControl.Instance.PlaySound(SoundEffectClip.StageCompleted);

		GlobalVariables.PlayerObject.collider2D.enabled = false;
		GlobalVariables.EnemySpawner.RemoveAll ();
		GlobalVariables.ItemSpawner.RemoveAll ();

		State = LevelState.Interlude;
	}

	/// <summary>
	/// Raises the interlude event.
	/// </summary>
	private IEnumerator OnInterlude()
	{
		GlobalVariables.HUDControl.StageCompleted();

		while ((GlobalVariables.PlayerObject.transform.position.y - GlobalVariables.PlayerObject.renderer.bounds.size.y / 2) < GlobalVariables.WorldSize.y)
		{
			yield return 0;
		}

		GlobalVariables.HUDControl.DeactivateStageText();

		Invoke ("WaitToNextStage", 2.5f);
	}

	/// <summary>
	/// Deactivates the stage text.
	/// </summary>
	private void WaitToNextStage()
	{
		GlobalVariables.HUDControl.NextStage();
		
		SoundEffectControl.Instance.ContinueMusic();
		GlobalVariables.PlayerObject.transform.position = startPlayerPosition;
		
		State = LevelState.Begin;
	}

	/// <summary>
	/// Raises the game over event.
	/// </summary>
	private void OnGameOver()
	{
		ActiveScripts (false);

		SoundEffectControl.Instance.PlaySound(SoundEffectClip.GameOver);

		GlobalVariables.HUDControl.ActiveGameOver ();
	}

	/// <summary>
	/// Actives the scripts.
	/// </summary>
	/// <param name="active">If set to <c>true</c> active.</param>
	private void ActiveScripts (bool active)
	{
		GlobalVariables.PlayerMovement.enabled = active;
		GlobalVariables.PlayerWeapon.enabled = active;
		
		GlobalVariables.ItemSpawner.enabled = active;
	}

	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	protected override void FixedUpdate ()
	{
		if (currentState == LevelState.Begin || currentState == LevelState.Interlude)
		{
			var direction = Vector2.up * 2f;

			GlobalVariables.PlayerObject.rigidbody2D.velocity = direction;
		}
	}

	#endregion
}