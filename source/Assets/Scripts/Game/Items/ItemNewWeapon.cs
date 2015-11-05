using UnityEngine;
using System.Collections;

/// <summary>
/// Provides a new weapon for player.
/// </summary>
public class ItemNewWeapon : BaseItem 
{
	#region [ FIELDS ]

	/// <summary>
	/// The guns to activate.
	/// </summary>
	[SerializeField]
	private PlayerGun[] gunsToActivate;

	#endregion

	#region [ METHODS ]

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		if (gunsToActivate.Length == 0)
		{
			Debug.LogError("The guns to activate were not set!");
		}

		base.Start ();
	}

	/// <summary>
	/// Raises the collected event.
	/// </summary>
	public override void OnCollected ()
	{
		base.OnCollected ();

		FeedbackPooling.Instance.Show(transform.position, "new gun(s)");

		GlobalVariables.PlayerWeapon.ActivateGuns(gunsToActivate);
		GlobalVariables.HUDControl.ImproveGun (spriteRenderer.sprite);
	}
	
	#endregion
}