using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy who move down and up.
/// </summary>
public class EnemyFlip : BaseEnemy 
{
	#region [ FIELDS ]

	/// <summary>
	/// The turned.
	/// </summary>
	private bool turned = false;
	/// <summary>
	/// The last direction.
	/// </summary>
	private Vector2 lastDirection;
	/// <summary>
	/// The original rotation.
	/// </summary>
	private Quaternion originalRotation;

	#endregion

	#region [ METHODS ]

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		base.Start ();

		originalRotation = transform.rotation;
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	protected override void Update ()
	{
		if (turned && (transform.position.y - boundSize.y) > GlobalVariables.WorldSize.y)
		{
			ExecuteBeforeBorn ();

			Active = false;

			return;
		}

		if (!turned)
		{
			Vector2 direction = -transform.up;
		
			if ((transform.position.y - boundSize.y / 2) < -GlobalVariables.WorldSize.y / 2)
			{
				Quaternion currentRotation = transform.rotation;
				currentRotation.z = 0f;
				transform.rotation = currentRotation;

				turned = true;
			}

			lastDirection = direction;
		}

		transform.Translate (lastDirection * speed * Time.deltaTime);
	}

	/// <summary>
	/// Executes the before born.
	/// </summary>
	protected override void ExecuteBeforeBorn ()
	{
		turned = false;
		transform.rotation = originalRotation;
	}

	#endregion
}