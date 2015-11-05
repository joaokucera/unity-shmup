using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A class to control the spawn of enemies.
/// </summary>
public class EnemySpawner : BaseScript 
{
	#region [ FIELDS ]

	/// <summary>
	/// The enemy big pool.
	/// </summary>
	[SerializeField]
	private EnemyPooling enemyBigPool;
	/// <summary>
	/// The enemy cargo pool.
	/// </summary>
	[SerializeField]
	private EnemyPooling enemyCargoPool;
	/// <summary>
	/// The enemy turn pool.
	/// </summary>
	[SerializeField]
	private EnemyPooling enemyTurnPool;
	/// <summary>
	/// The enemy ordinary pool.
	/// </summary>
	[SerializeField]
	private EnemyPooling enemyOrdinaryPool;
	/// <summary>
	/// The enemy flip pool.
	/// </summary>
	[SerializeField]
	private EnemyPooling enemyFlipPool;
	/// <summary>
	/// The enemy rear pool.
	/// </summary>
	[SerializeField]
	private EnemyPooling enemyRearPool;
	/// <summary>
	/// The enemy acrobatic pool.
	/// </summary>
	[SerializeField]
	private EnemyPooling enemyAcrobaticPool;
	/// <summary>
	/// The probability percentages.
	/// </summary>
	[SerializeField]
	private int[] probabilityPercentages = new int[7];
	/// <summary>
	/// The probability pool.
	/// </summary>
	private List<EnemyType> probabilityPool = new List<EnemyType>();
	/// <summary>
	/// The spawned enemies.
	/// </summary>
	private List<GameObject> spawnedEnemies = new List<GameObject>();

	#endregion

	#region [ METHODS ]

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
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
				probabilityPool.Add((EnemyType)i);	
			}
		}
	}

	/// <summary>
	/// Spawn this instance.
	/// </summary>
	public void Spawn ()
	{
		int random = Random.Range (0, probabilityPool.Count);
		EnemyType type = probabilityPool [random];

		GameObject spawnedEnemy = null;

		switch (type)
		{
			case EnemyType.Acrobatic:
			{
				float xPos = 0;
				float yPos = Random.Range(-GlobalVariables.WorldSize.y, 0);
				
				spawnedEnemy = enemyAcrobaticPool.GetObjectFromPool(new Vector2(xPos, yPos)) as GameObject;
				EnemyAcrobatic acrobatic = spawnedEnemy.GetComponent<EnemyAcrobatic>();

				int value = Random.Range(-1, 1);
				if (value >= 0)
				{
					xPos = GlobalVariables.WorldSize.x * 1.25f;	
					acrobatic.Movement = EnemyMovement.Left;
				}
				else
				{
					xPos = -GlobalVariables.WorldSize.x * 1.25f;
					acrobatic.Movement = EnemyMovement.Right;
				}

				acrobatic.transform.position = new Vector2(xPos, yPos);

				break;
			}
			case EnemyType.Big:
			{
				float xPos = Random.Range(-GlobalVariables.WorldSize.x / 1.5f, GlobalVariables.WorldSize.x / 1.5f);	
				float yPos = -GlobalVariables.WorldSize.y * 1.25f;

				spawnedEnemy = enemyBigPool.GetObjectFromPool(new Vector2(xPos, yPos)) as GameObject;

				break;
			}
			case EnemyType.Cargo:
			{
				float xPos = Random.Range(-GlobalVariables.WorldSize.x / 1.25f, GlobalVariables.WorldSize.x / 1.25f);	
				float yPos = -GlobalVariables.WorldSize.y * 1.25f;

				spawnedEnemy = enemyCargoPool.GetObjectFromPool(new Vector2(xPos, yPos)) as GameObject;

				break;
			}
			case EnemyType.Flip:
			{
				float xPos = Random.Range(-GlobalVariables.WorldSize.x / 1.25f, GlobalVariables.WorldSize.x / 1.25f);	
				float yPos = GlobalVariables.WorldSize.y * 1.25f;
				
				spawnedEnemy = enemyFlipPool.GetObjectFromPool(new Vector2(xPos, yPos)) as GameObject;

				break;
			}
			case EnemyType.Ordinary:
			{
				float xPos = Random.Range(-GlobalVariables.WorldSize.x / 1.25f, GlobalVariables.WorldSize.x / 1.25f);	
				float yPos = GlobalVariables.WorldSize.y * 1.25f;
				
				spawnedEnemy = enemyOrdinaryPool.GetObjectFromPool(new Vector2(xPos, yPos)) as GameObject;

				break;
			}
			case EnemyType.Rear:
			{
				float xPos = Random.Range(-GlobalVariables.WorldSize.x / 1.25f, GlobalVariables.WorldSize.x / 1.25f);	
				float yPos = -GlobalVariables.WorldSize.y * 1.25f;

				spawnedEnemy = enemyRearPool.GetObjectFromPool(new Vector2(xPos, yPos)) as GameObject;

				break;
			}
			case EnemyType.Turn:
			{
				float xPos = 0;
				float yPos = GlobalVariables.WorldSize.y * 1.25f;

				int value = Random.Range(-1, 1);
				if (value >= 0)
			    {
					xPos = GlobalVariables.WorldSize.x / 1.25f;	
				}
				else
				{
				  	xPos = -GlobalVariables.WorldSize.x / 1.25f;	
				}
			
				spawnedEnemy = enemyTurnPool.GetObjectFromPool(new Vector2(xPos, yPos)) as GameObject;

				break;
			}
		}

		if (spawnedEnemy != null)
		{
			spawnedEnemies.Add(spawnedEnemy);
		}
	}

	/// <summary>
	/// Removes all.
	/// </summary>
	public void RemoveAll ()
	{
		spawnedEnemies.ForEach(e => 
		{
			if (e.activeInHierarchy)
			{
				ExplosionPooling.Instance.Show(e.transform.position, e.transform.rotation);

				e.SetActive(false);
			}
		});

		spawnedEnemies.Clear ();
	}

	#endregion
}