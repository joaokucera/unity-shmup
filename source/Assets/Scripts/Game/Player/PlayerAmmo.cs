using UnityEngine;
using System.Collections;

/// <summary>
/// Ammo who hits the enemy.
/// </summary>
public class PlayerAmmo : BaseAmmo
{
    #region [ FIELDS ]

    #endregion

	#region [ METHODS ]

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		base.Start ();

		gameObject.tag = ShortcutWords.PlayerAttackTag;
	}

	#endregion
}