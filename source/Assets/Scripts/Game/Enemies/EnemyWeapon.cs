using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// A class to control when an enemy can shoot.
/// </summary>
public class EnemyWeapon : GenericPooling
{
	#region [ FIELDS ]

	/// <summary>
	/// The shot speed.
	/// </summary>
	[SerializeField]
	private float shotSpeed = 100f;
	/// <summary>
	/// The weapon rate.
	/// </summary>
	[SerializeField]
	private float weaponRate = 5f;
	/// <summary>
	/// The weapon cooldown.
	/// </summary>
	private float weaponCooldown;
	/// <summary>
	/// The guns.
	/// </summary>
	private List<Transform> guns = new List<Transform>();
	
	#endregion
	
	#region [ METHODS ]
	
	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		base.Start ();

		for (int i = 0; i < transform.childCount; i++) 
		{
			var child = transform.GetChild(i);

			guns.Add(child);
		}
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
		else
		{
			weaponCooldown = weaponRate;
			
			guns.ForEach(g => 
			{
				GameObject ammo = GetObjectFromPool (g.position, g.rotation);
				
				if (ammo != null)
				{
					Vector2 direction = ammo.transform.up;
					Vector2 force = direction * shotSpeed;
					
					ammo.transform.rigidbody2D.AddForce(force);
				}
			});
		}
	}

	#endregion
}