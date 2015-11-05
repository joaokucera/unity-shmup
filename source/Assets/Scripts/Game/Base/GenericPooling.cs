using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A generic pooling script to control gameobject's activations and to avoid instantiate and destroy gameobjects many times.
/// </summary>
public abstract class GenericPooling : BaseScript
{
    #region [ FIELDS ]

    /// <summary>
    /// The prefab.
    /// </summary>
    [SerializeField]
    protected GameObject prefab;
    /// <summary>
    /// The initial size of pool.
    /// </summary>
    [SerializeField]
    protected int poolSize = 1;
    /// <summary>
    /// If pool can grow or not.
    /// </summary>
    [SerializeField]
	protected bool poolCanGrow = false;
    /// <summary>
    /// A pool of prefab object.
    /// </summary>
    private List<GameObject> pool = new List<GameObject>();
	/// <summary>
	/// The parent.
	/// </summary>
	private Transform parent;

    #endregion

	#region [ PROPERTIES ]

	/// <summary>
	/// Sets the parent.
	/// </summary>
	/// <value>The parent.</value>
	protected Transform Parent
	{
		get
		{
			if (parent == null)
			{
				parent = GlobalVariables.PoolingRepository;
			}

			return parent;
		}
		set
		{
			parent = value;
		}
	}

	#endregion

    #region [ METHODS ]

    /// <summary>
    /// Called when script start.
    /// </summary>
    protected override void Start ()
    {
        StartPool();
    }

    /// <summary>
    /// Initializes pool.
    /// </summary>
    private void StartPool()
    {
        if (prefab == null)
        {
			Debug.LogError("The prefab was not set!");
        }

        for (int i = 0; i < poolSize; i++)
        {
            CreateNewObject();
        }
    }

    /// <summary>
    /// Get a game object from pool.
    /// </summary>
    /// <param name="position">The positoin.</param>
    /// <param name="active">Is if active or not.</param>
    /// <returns>Returns a game object from pool.</returns>
    public GameObject GetObjectFromPool(Vector2 position, Quaternion rotation, bool active = true)
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return PrepareObjectToResponse(obj, position, rotation, active);
            }
        }

        if (poolCanGrow)
        {
            GameObject obj = CreateNewObject();

            return PrepareObjectToResponse(obj, position, rotation, active);
        }

        return null;
    }

	/// <summary>
	/// Gets the object from pool.
	/// </summary>
	/// <returns>The object from pool.</returns>
	/// <param name="position">Position.</param>
	/// <param name="active">If set to <c>true</c> active.</param>
	public GameObject GetObjectFromPool(Vector2 position, bool active = true)
	{
		foreach (GameObject obj in pool)
		{
			if (!obj.activeInHierarchy)
			{
				return PrepareObjectToResponse(obj, position, active);
			}
		}
		
		if (poolCanGrow)
		{
			GameObject obj = CreateNewObject();
			
			return PrepareObjectToResponse(obj, position, active);
		}
		
		return null;
	}

    /// <summary>
    /// Creates a new game object.
    /// </summary>
    /// <returns>Returns a new game object.</returns>
    private GameObject CreateNewObject()
    {
        GameObject newObject = Instantiate(prefab) as GameObject;
        newObject.SetActive(false);

		newObject.transform.SetParent(Parent);

        pool.Add(newObject);

        return newObject;
    }

    /// <summary>
    /// Prepare a game object to response.
    /// </summary>
    /// <param name="obj">The game object.</param>
    /// <param name="position">The position.</param>
    /// <param name="active">Is is active or not.</param>
    /// <returns>Returns the game object.</returns>
    private GameObject PrepareObjectToResponse(GameObject obj, Vector2 position, Quaternion rotation, bool active)
    {
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(active);

        return obj;
    }

	/// <summary>
	/// Prepare a game object to response.
	/// </summary>
	/// <param name="obj">The game object.</param>
	/// <param name="position">The position.</param>
	/// <param name="active">Is is active or not.</param>
	/// <returns>Returns the game object.</returns>
	private GameObject PrepareObjectToResponse(GameObject obj, Vector2 position, bool active)
	{
		obj.transform.position = position;
		obj.SetActive(active);
		
		return obj;
	}

    #endregion
}