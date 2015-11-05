using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Provides a new life for player.
/// </summary>
public class ItemNewLife : BaseItem 
{
	#region [ FIELDS ]

	/// <summary>
	/// The gain life.
	/// </summary>
	[SerializeField]
	private int gainLife = 1;

	#endregion
	
	#region [ METHODS ]

	/// <summary>
	/// Raises the collected event.
	/// </summary>
	public override void OnCollected ()
	{
		base.OnCollected ();

		GlobalVariables.PlayerHealth.AddLife (gainLife);
	}

	#endregion
}