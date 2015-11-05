using UnityEngine;
using System.Collections;

/// <summary>
/// An abstract class to be a reference for any other ammo classes.
/// </summary>
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseAmmo : BaseScript
{
    #region [ FIELDS ]

    /// <summary>
    /// The current damage.
    /// </summary>
	[SerializeField]
    protected int damage = 1;

    #endregion

    #region [ PROPERTIES ]

	/// <summary>
	/// Gets the damage.
	/// </summary>
	/// <value>The damage.</value>
    public int Damage
    {
        get { return damage; }
    }

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
	}

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    protected override void Update ()
    {
        if (!renderer.isVisible)
        {
            Active = false;
        }
    }

    #endregion
}