using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy who attacks from screen sides.
/// </summary>
public class EnemyAcrobatic : BaseEnemy 
{
	#region [ FIELDS ]

	/// <summary>
	/// The movement.
	/// </summary>
	[SerializeField]
	private EnemyMovement movement = EnemyMovement.Left;
	/// <summary>
	/// The turned.
	/// </summary>
	private bool turned = false;
	/// <summary>
	/// The last direction.
	/// </summary>
	private Vector2 lastDirection;
	/// <summary>
	/// The original rotation.
	/// </summary>
	private Quaternion originalRotation;

	#endregion

	#region [ PROPERTIES ]

	/// <summary>
	/// Gets or sets the enemy movement.
	/// </summary>
	/// <value>The enemy movement.</value>
	public EnemyMovement Movement 
	{
		set
		{
			movement = value;

			if (movement == EnemyMovement.Left)
			{
				transform.rotation = Quaternion.Euler(0f, 0f, 90f);
			}
			else if (movement == EnemyMovement.Right)
			{
				transform.rotation = Quaternion.Euler(0f, 0f, -90f);
			}
		}
	}

	#endregion
	
	#region [ METHODS ]
	
	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		base.Start ();

		originalRotation = transform.rotation;
	}
	
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	protected override void Update ()
	{
		if ((transform.position.y - boundSize.y) > GlobalVariables.WorldSize.y)
		{
			ExecuteBeforeBorn ();

			Active = false;

			return;
		}

		if (!turned)
		{
			Vector2 direction = Vector2.zero;

			if (movement == EnemyMovement.Left)
			{
				direction = transform.right;

				if ((transform.position.x - boundSize.x / 2) < 0)
				{
					StartCoroutine(Turning());
					turned = true;
				}
			}
			else if (movement == EnemyMovement.Right)
			{
				direction = -transform.right;

				if ((transform.position.x + boundSize.x / 2) > 0)
				{
					StartCoroutine(Turning());
					turned = true;
				}
			}
			
			lastDirection = direction;
		}
		
		transform.Translate (lastDirection * speed * Time.deltaTime);
	}

	/// <summary>
	/// Turning this instance.
	/// </summary>
	private IEnumerator Turning()
	{
		Quaternion currentRotation = transform.rotation;

		while (currentRotation.z > 0) 
		{
			currentRotation.z -= Time.deltaTime;
			transform.rotation = currentRotation;

			yield return 0;
		}

		lastDirection = transform.up;
	}

	/// <summary>
	/// Executes the before born.
	/// </summary>
	protected override void ExecuteBeforeBorn ()
	{
		turned = false;
		transform.rotation = originalRotation;
	}

	#endregion
}