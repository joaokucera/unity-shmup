using UnityEngine;
using System.Collections;

/// <summary>
/// A specialization class to control pool of explosions.
/// </summary>
public class ExplosionPooling : GenericPooling 
{
	#region [ FIELDS ]
	
	/// <summary>
	/// The instance.
	/// </summary>
	private static ExplosionPooling instance;
	
	#endregion
	
	#region [ PROPERTIES ]
	
	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static ExplosionPooling Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<ExplosionPooling>();
			}
			
			return instance;
		}
	}
	
	#endregion

	#region [ METHODS ]

	/// <summary>
	/// Show the specified position and rotation.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="rotation">Rotation.</param>
	public void Show (Vector3 position, Quaternion rotation)
	{
		GetObjectFromPool (position, rotation);
	}

	#endregion
}