using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy who just moves down.
/// </summary>
public class EnemyOrdinary : BaseEnemy 
{
	#region [ METHODS ]

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	protected override void Update ()
	{
		if ((transform.position.y + boundSize.y) < -GlobalVariables.WorldSize.y)
		{
			Active = false;

			return;
		}

		Vector2 direction = -transform.up;

		transform.Translate (direction * speed * Time.deltaTime);
	}

	/// <summary>
	/// Executes the before born.
	/// </summary>
	protected override void ExecuteBeforeBorn ()
	{
	}

	#endregion
}