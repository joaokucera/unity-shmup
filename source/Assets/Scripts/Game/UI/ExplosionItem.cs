using UnityEngine;
using System.Collections;

/// <summary>
/// Controls each explosion effect.
/// </summary>
public class ExplosionItem : BaseScript 
{
	#region [ METHODS ]

	/// <summary>
	/// Hide this instance.
	/// </summary>
	public void Hide ()
	{
		gameObject.SetActive (false);
	}
	
	#endregion
}