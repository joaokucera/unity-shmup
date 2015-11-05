using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// An abstract class to be a reference for any other item classes.
/// </summary>
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class BaseItem : BaseScript
{
	#region [ FIELDS ]
	
	/// <summary>
	/// The sprite renderer.
	/// </summary>
	protected SpriteRenderer spriteRenderer;

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

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
    /// </summary>
	protected override void Start ()
    {
		collider2D.isTrigger = true;

		spriteRenderer = renderer as SpriteRenderer;
    }

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this object (2D physics only).
	/// </summary>
	/// <param name="collider">Collider.</param>
	protected override void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.CompareTag(ShortcutWords.PlayerTag))
		{
			OnCollected();

			SoundEffectControl.Instance.PlaySound(SoundEffectClip.CollectingItem);

			Active = false;
		}
	}

	/// <summary>
	/// Show the specified position.
	/// </summary>
	/// <param name="position">Position.</param>
	public void Show(Vector2 position)
	{
		transform.position = position;
		Active = true;

		StartCoroutine("DeactivateItem");
	}

	/// <summary>
	/// Deactivates the item.
	/// </summary>
	/// <returns>The item.</returns>
	private IEnumerator DeactivateItem()
	{
		yield return new WaitForSeconds (10f);
	
		Active = false;
	}

    /// <summary>
    /// Raises the collected event.
    /// </summary>
	public virtual void OnCollected()
	{
		StopCoroutine ("DeactivateItem");
	}

    #endregion
}