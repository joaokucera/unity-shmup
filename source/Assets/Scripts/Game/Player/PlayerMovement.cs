using System.Collections;
using UnityEngine;

/// <summary>
/// Controls the player's movement.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : BaseScript
{
    #region [ FIELDS ]
    
	/// <summary>
	/// The speed.
	/// </summary>
	[SerializeField]
	private float movementSpeed = 1f;
	/// <summary>
	/// The movement.
	/// </summary>
	private Vector2 movement;

    #endregion

	#region [ PROPERTIES ]

	#endregion

    #region [ METHODS ]

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		rigidbody2D.fixedAngle = true;
	}

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
	protected override void Update ()
    {
		movement = InputControl.GetMovement();

		transform.EnforceBounds(Camera.main, renderer);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
	protected override void FixedUpdate ()
    {
		rigidbody2D.velocity = movement * movementSpeed;
    }

    #endregion
}