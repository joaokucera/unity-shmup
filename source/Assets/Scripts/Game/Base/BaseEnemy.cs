using UnityEngine;
using System.Collections;

/// <summary>
/// An abstract class to be a reference for any other enemies classes.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class BaseEnemy : BaseScript
{
	#region [ FIELDS ]

	/// <summary>
	/// The weapon.
	/// </summary>
	private EnemyWeapon weapon;
	/// <summary>
	/// The points.
	/// </summary>
	[SerializeField]
	private int points = 1;
	/// <summary>
	/// The speed.
	/// </summary>
	[SerializeField]
	protected float speed = 1f;
	/// <summary>
	/// The size of the bound.
	/// </summary>
	protected Vector2 boundSize;

	#endregion

	#region [ PROPERTIES ]

	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="BaseAmmo"/> is active.
	/// </summary>
	/// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
	protected bool Active
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

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		collider2D.isTrigger = true;

		rigidbody2D.fixedAngle = true;
		rigidbody2D.isKinematic = true;
		
		boundSize = renderer.bounds.size;

		weapon = GetComponentInChildren<EnemyWeapon>();
	}

	/// <summary>
	/// Executes the after dying.
	/// </summary>
	public void ExecuteAfterDying ()
	{
		ExecuteBeforeBorn ();

		FeedbackPooling.Instance.Show (transform.position, "+ " + points);
		GlobalVariables.HUDControl.AddPoints (points);

		Active = false;
	}

	/// <summary>
	/// Executes the before born.
	/// </summary>
	protected abstract void ExecuteBeforeBorn();

	/// <summary>
	/// OnBecameVisible is called when the renderer became visible by any camera.
	/// </summary>
	protected override void OnBecameVisible ()
	{
		collider2D.enabled = true;

		if (weapon)
		{
			weapon.enabled = true;
		}
	}
	
	/// <summary>
	/// OnBecameInvisible is called when the renderer is no longer visible by any camera.
	/// </summary>
	protected override void OnBecameInvisible ()
	{
		collider2D.enabled = false;

		if (weapon)
		{
			weapon.enabled = false;
		}
	}

	#endregion
}