using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

/// <summary>
/// Controls the player's shooting.
/// </summary>
public class PlayerWeapon : GenericPooling
{
    #region [ FIELDS ]

	/// <summary>
	/// The shot speed.
	/// </summary>
	[SerializeField]
	private float shotSpeed = 250f;
	/// <summary>
	/// The weapon rate.
	/// </summary>
	[SerializeField]
	private float weaponRate = 0.25f;
	/// <summary>
	/// The weapon cooldown.
	/// </summary>
	private float weaponCooldown;
	/// <summary>
	/// The guns.
	/// </summary>
	[SerializeField]
	private List<Transform> guns = new List<Transform>();

    #endregion

    #region [ METHODS ]

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		if (guns.Count == 0)
		{
			Debug.LogError("The guns were not set!");
		}

		base.Start ();

		guns.ForEach(g => g.gameObject.SetActive(false));
		guns [0].gameObject.SetActive (true);
	}

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    protected override void Update ()
    {
		if (weaponCooldown > 0)
		{
			weaponCooldown -= Time.deltaTime;
		}

		UpdateWeapon ();
    }

	/// <summary>
	/// Updates the weapon.
	/// </summary>
	private void UpdateWeapon ()
	{
		if (weaponCooldown <= 0 && InputControl.IsShotEnabled && !EventSystem.current.IsPointerOverGameObject ())
		{
			weaponCooldown = weaponRate;

			guns.Where(g => g.gameObject.activeInHierarchy).ToList().ForEach(g => 
			{
				GameObject ammo = GetObjectFromPool (g.position, g.rotation);

				if (ammo != null)
				{
					Vector2 direction = ammo.transform.up;
					Vector2 force = direction * shotSpeed;
					
					ammo.transform.rigidbody2D.AddForce(force);
				}
			});

			SoundEffectControl.Instance.PlaySound(SoundEffectClip.PlayerShot);
		}
	}

	/// <summary>
	/// Activates the guns.
	/// </summary>
	/// <param name="gunsToActivate">Guns to activate.</param>
	public void ActivateGuns (PlayerGun[] gunsToActivate)
	{
		guns.ForEach (g => g.gameObject.SetActive(false));

		for (int i = 0; i < gunsToActivate.Length; i++)
		{
			int index = (int)gunsToActivate[i];

			guns[index].gameObject.SetActive(true);
		}
	}

	#endregion
}