using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy that throws items when destroyed.
/// </summary>
public class EnemyCargo : BaseEnemy 
{
	#region [ METHODS ]

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	protected override void Update ()
	{
		if ((transform.position.y - boundSize.y) > GlobalVariables.WorldSize.y)
		{
			Active = false;

			return;
		}

		var translation = transform.up * speed * Time.deltaTime;

		transform.Translate (translation);
	}

	/// <summary>
	/// Executes the before born.
	/// </summary>
	protected override void ExecuteBeforeBorn ()
	{
		GlobalVariables.ItemSpawner.Spawn (transform.position);
	}

	#endregion
}