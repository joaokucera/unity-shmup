using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// A class to control the activation of items.
/// </summary>
public class ItemSpawner : BaseScript 
{
	#region [ FIELDS ]

	/// <summary>
	/// The items.
	/// </summary>
	[SerializeField]
	private BaseItem[] items = new BaseItem[5];
	/// <summary>
	/// The probability percentages.
	/// </summary>
	[SerializeField]
	private int[] probabilityPercentages = new int[6];
	/// <summary>
	/// The probability pool.
	/// </summary>
	private List<int> probabilityPool = new List<int>();

	#endregion
	
	#region [ METHODS ]

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		foreach (var item in items)
		{
			item.Active = false;
		}

		InitializeProbabilityPool ();
	}

	/// <summary>
	/// Initializes the probability pool.
	/// </summary>
	private void InitializeProbabilityPool ()
	{
		for (int i = 0; i < probabilityPercentages.Length; i++) 
		{
			for (int k = 0; k < probabilityPercentages[i]; k++)
			{
				probabilityPool.Add(i - 1);	
			}
		}
	}

	/// <summary>
	/// Gets the item.
	/// </summary>
	/// <returns>The item.</returns>
	public void Spawn(Vector2 position)
	{
		int random = Random.Range (0, probabilityPool.Count);
		int index = probabilityPool [random];

		// -1 means to spawn nothing.
		if (index > -1)
		{
			items[index].Show(position);
		}
	}

	/// <summary>
	/// Removes all.
	/// </summary>
	public void RemoveAll ()
	{
		foreach (BaseItem item in items) 
		{
			item.Active = false;
		}
	}

	#endregion
}