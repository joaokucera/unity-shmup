using UnityEngine;
using System.Collections;

/// <summary>
/// A central point of important references for the game to avoid to use getcomponent method many times.
/// </summary>
public class GlobalVariables : BaseScript 
{
	#region [ FIELDS ]

	/// <summary>
	/// The player object.
	/// </summary>
	private static GameObject playerObject;
	/// <summary>
	/// The player movement script.
	/// </summary>
	private static PlayerMovement playerMovementScript;
	/// <summary>
	/// The player health script.
	/// </summary>
	private static PlayerHealth playerHealthScript;
	/// <summary>
	/// The player weapon script.
	/// </summary>
	private static PlayerWeapon playerWeaponScript;
	/// <summary>
	/// The ammo parent.
	/// </summary>
	private static Transform poolingRepository;
	/// <summary>
	/// The hud.
	/// </summary>
	private static HUDControl hud;
	/// <summary>
	/// The item spawner.
	/// </summary>
	private static ItemSpawner itemSpawner;
	/// <summary>
	/// The size of the world.
	/// </summary>
	private static Vector3 worldSize = Vector3.zero;
	/// <summary>
	/// The enemy spawner.
	/// </summary>
	private static EnemySpawner enemySpawner;
	/// <summary>
	/// The level control.
	/// </summary>
	private static LevelControl levelControl;

	#endregion

	#region [ PROPERTIES ]

	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="GlobalVariables"/> is paused.
	/// </summary>
	/// <value><c>true</c> if paused; otherwise, <c>false</c>.</value>
	public static bool Paused 
	{
		get
		{
			if (Time.timeScale == 0f)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		set
		{
			if (value)
			{
				Time.timeScale = 0f;
				AudioListener.pause = true;
			}
			else
			{
				Time.timeScale = 1f;
				AudioListener.pause = false;
			}
		}
	}
	/// <summary>
	/// Gets the player object.
	/// </summary>
	/// <value>The player object.</value>
	public static GameObject PlayerObject 
	{
		get
		{
			if (playerObject == null)
			{
				playerObject = GameObject.FindGameObjectWithTag(ShortcutWords.PlayerTag);
			}

			return playerObject;
		}
	}
	/// <summary>
	/// Gets the player movement.
	/// </summary>
	/// <value>The player movement.</value>
	public static PlayerMovement PlayerMovement
	{
		get
		{
			if (playerMovementScript == null)
			{
				playerMovementScript = PlayerObject.GetComponent<PlayerMovement>();
			}
			
			return playerMovementScript;
		}
	}
	/// <summary>
	/// Gets the player movement.
	/// </summary>
	/// <value>The player movement.</value>
	public static PlayerHealth PlayerHealth
	{
		get
		{
			if (playerHealthScript == null)
			{
				playerHealthScript = PlayerObject.GetComponent<PlayerHealth>();
			}
			
			return playerHealthScript;
		}
	}
	/// <summary>
	/// Gets the player movement.
	/// </summary>
	/// <value>The player movement.</value>
	public static PlayerWeapon PlayerWeapon
	{
		get
		{
			if (playerWeaponScript == null)
			{
				playerWeaponScript = PlayerObject.GetComponentInChildren<PlayerWeapon>();
			}
			
			return playerWeaponScript;
		}
	}
	/// <summary>
	/// Gets the ammunitions.
	/// </summary>
	/// <value>The ammunitions.</value>
	public static Transform PoolingRepository 
	{
		get
		{
			if (poolingRepository == null)
			{
				poolingRepository = GameObject.FindGameObjectWithTag(ShortcutWords.PoolingTag).transform;
			}
			
			return poolingRepository;
		}
	}
	/// <summary>
	/// Gets the hud.
	/// </summary>
	/// <value>The hud.</value>
	public static HUDControl HUDControl 
	{
		get
		{
			if (hud == null)
			{
				hud = GameObject.FindObjectOfType<HUDControl>();
			}
			
			return hud;
		}
	}
	/// <summary>
	/// Gets the item spawner.
	/// </summary>
	/// <value>The item spawner.</value>
	public static ItemSpawner ItemSpawner 
	{
		get
		{
			if (itemSpawner == null)
			{
				itemSpawner = GameObject.FindObjectOfType<ItemSpawner>();
			}
			
			return itemSpawner;
		}
	}
	/// <summary>
	/// Gets or sets the size of the world.
	/// </summary>
	/// <value>The size of the world.</value>
	public static Vector3 WorldSize
	{
		get
		{
			if (worldSize == Vector3.zero)
			{
				Camera mainCamera = Camera.main;

				worldSize = new Vector3(mainCamera.orthographicSize * mainCamera.aspect, mainCamera.orthographicSize, 0f);
			}

			return worldSize;
		}
	}
	/// <summary>
	/// Gets the enemy spawner.
	/// </summary>
	/// <value>The enemy spawner.</value>
	public static EnemySpawner EnemySpawner 
	{
		get
		{
			if (enemySpawner == null)
			{
				enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
			}
			
			return enemySpawner;
		}
	}
	/// <summary>
	/// Gets the level control.
	/// </summary>
	/// <value>The level control.</value>
	public static LevelControl LevelControl 
	{
		get
		{
			if (levelControl == null)
			{
				levelControl = GameObject.FindObjectOfType<LevelControl>();
			}
			
			return levelControl;
		}
	}


	#endregion
}