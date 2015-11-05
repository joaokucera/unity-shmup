using UnityEngine;
using System.Collections;

/// <summary>
/// To control the enemy's health.
/// </summary>
[RequireComponent(typeof(BaseEnemy))]
public class EnemyHealth : BaseHealth 
{
	#region [ FIELDS ]

	/// <summary>
	/// The enemy behavior.
	/// </summary>
	private BaseEnemy enemyBehavior;
	/// <summary>
	/// The color of the original.
	/// </summary>
	private Color originalColor;
	/// <summary>
	/// The color of the hit.
	/// </summary>
	private Color hitColor;
	
	#endregion

	#region [ PROPERTIES ]

	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="BaseAmmo"/> is active.
	/// </summary>
	/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
	public bool Active
	{
		get 
		{
			return gameObject.activeInHierarchy; 
		}
		set 
		{ 
			gameObject.SetActive(value); 
		}
	}
	
	#endregion

	#region [ METHODS ]

	#region implemented abstract members of BaseHealth

	/// <summary>
	/// Raises the death event.
	/// </summary>
	protected override void OnDeath ()
	{
		enemyBehavior.ExecuteAfterDying ();

		currentLives = extraLives;
	}

	/// <summary>
	/// Raises the blink event.
	/// </summary>
	protected override void OnBlink ()
	{
		Color color = renderer.material.color;

		if (color == originalColor)
		{
			color.g = hitColor.g;
			color.b = hitColor.b;
		}
		else if (color == hitColor)
		{
			color.g = originalColor.g;
			color.b = originalColor.b;
		}

		renderer.material.color = color;
	}

	#endregion

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		base.Start ();

		enemyBehavior = GetComponent<BaseEnemy> ();

		hitAgainstAttackTag = AttackTag.PlayerAttack;

		originalColor = renderer.material.color;
		hitColor = Color.red;
	}

	/// <summary>
	/// Raises the recover event.
	/// </summary>
	protected override void OnRecover()
	{
		base.OnRecover();
		
		renderer.material.color = originalColor;
	}

	#endregion
}