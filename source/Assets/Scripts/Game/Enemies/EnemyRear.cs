using UnityEngine;
using System.Collections;

/// <summary>
/// A dangerous enemy.
/// </summary>
public class EnemyRear : BaseEnemy 
{
	#region [ FIELDS ]

	/// <summary>
	/// At position to attack.
	/// </summary>
	private bool atPositionToStop;
	/// <summary>
	/// The y position to stop.
	/// </summary>
	private float yPositionToStop;

	#endregion
	
	#region [ METHODS ]
	
	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		base.Start ();

		ExecuteBeforeBorn ();
	}
	
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	protected override void Update ()
	{
		if (!atPositionToStop)
		{
			Vector2 direction = transform.up;

			transform.Translate (direction * speed * Time.deltaTime);

			if ((transform.position.y + boundSize.y / 2) > yPositionToStop)
			{
				atPositionToStop = true;
			}
		}
	}

	/// <summary>
	/// Executes the before born.
	/// </summary>
	protected override void ExecuteBeforeBorn ()
	{
		atPositionToStop = false;
		yPositionToStop = Random.Range (0, GlobalVariables.WorldSize.y / 1.5f);
	}

	#endregion
}