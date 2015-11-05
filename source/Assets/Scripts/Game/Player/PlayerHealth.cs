using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// To control the player's health.
/// </summary>
public class PlayerHealth : BaseHealth
{
    #region [ FIELDS ]

	/// <summary>
	/// The max lives.
	/// </summary>
	public const int PlayerMaxLives = 5;

	/// <summary>
	/// The damage hit against enemies.
	/// </summary>
	[SerializeField]
	private int damageHitAgainstEnemies = 1;
	/// <summary>
	/// The tails renderers.
	/// </summary>
	private SpriteRenderer[] renderers;

    #endregion

    #region [ METHODS ]
	
	#region implemented abstract members of BaseHealth
	
	/// <summary>
	/// Raises the death event.
	/// </summary>
	protected override void OnDeath()
	{
		GlobalVariables.LevelControl.State = LevelState.GameOver;

		gameObject.SetActive (false);
	}
	
	/// <summary>
	/// Raises the blink event.
	/// </summary>
	protected override void OnBlink()
	{
		foreach (var item in renderers) 
		{
			item.enabled = !item.enabled;
		}
	}
	
	#endregion

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		base.Start ();

		GlobalVariables.HUDControl.StartLives (currentLives);

		hitAgainstAttackTag = AttackTag.EnemyAttack;

		renderers = GetComponentsInChildren<SpriteRenderer> ();
	}

	/// <summary>
	/// Sent each frame where a collider on another object is touching this object's collider (2D physics only).
	/// </summary>
	/// <param name="collision">Collision.</param>
    protected override void OnTriggerStay2D (Collider2D collider)
    {
        if (!wasHit && collider.CompareTag(ShortcutWords.EnemyTag))
        {
			CameraShake.Instance.Shake ();

			RemoveLife(damageHitAgainstEnemies);
        }
    }

    /// <summary>
    /// Raises the recover event.
    /// </summary>
	protected override void OnRecover()
    {
		base.OnRecover();

		foreach (var item in renderers) 
		{
			item.enabled = true;
		}
    }

	/// <summary>
	/// Adds the life.
	/// </summary>
	/// <param name="gain">Gain.</param>
	public override void AddLife (int gain)
	{
		if (currentLives < PlayerMaxLives)
		{
			base.AddLife (gain);

			FeedbackPooling.Instance.Show(transform.position, "+ life");

			GlobalVariables.HUDControl.ActivateLifeIcon ();
		}
		else
		{
			FeedbackPooling.Instance.Show(transform.position, "max of lives");
		}
	}

	/// <summary>
	/// Removes the life.
	/// </summary>
	/// <param name="loss">Loss.</param>
	public override void RemoveLife (int loss)
	{
		base.RemoveLife (loss);

		GlobalVariables.HUDControl.DeactivateLifeIcon ();
	}

    #endregion
}