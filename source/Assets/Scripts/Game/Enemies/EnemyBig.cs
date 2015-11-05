using UnityEngine;
using System.Collections;

/// <summary>
/// The biggest enemy.
/// </summary>
public class EnemyBig : BaseEnemy 
{
	#region [ FIELDS ]
	
	/// <summary>
	/// The current movement.
	/// </summary>
	private EnemyMovement currentMovement;
	/// <summary>
	/// The last direction.
	/// </summary>
	private Vector2 direction;
	/// <summary>
	/// The waiting to move.
	/// </summary>
	[SerializeField]
	private float waitingToMove = 2.5f;
	/// <summary>
	/// The timer.
	/// </summary>
	private float timer;

	#endregion

	#region [ METHODS ]

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		base.Start ();

		ExecuteBeforeBorn ();
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	protected override void Update ()
	{
		EvaluateMovement ();

		transform.Translate (direction * speed * Time.deltaTime);
	}

	/// <summary>
	/// Movement this instance.
	/// </summary>
	private void EvaluateMovement ()
	{
		if (currentMovement == EnemyMovement.Up && (transform.position.y + boundSize.y / 2) > GlobalVariables.WorldSize.y / 1.5f) 
		{
			if (transform.position.x > 0)
			{
				StartCoroutine(WaitToMove(EnemyMovement.Left, -transform.right));
			}
			else 
			{
				StartCoroutine(WaitToMove(EnemyMovement.Right, transform.right));
			}
		}
		else if (currentMovement == EnemyMovement.Left && (transform.position.x + boundSize.x / 2) < -GlobalVariables.WorldSize.x / 2f) 
		{
			StartCoroutine(WaitToMove(EnemyMovement.Right, transform.right));
		}
		else if (currentMovement == EnemyMovement.Right && (transform.position.x - boundSize.x / 2) > GlobalVariables.WorldSize.x / 2f) 
		{
			StartCoroutine(WaitToMove(EnemyMovement.Left, -transform.right));
		}
	}

	/// <summary>
	/// Waits to move.
	/// </summary>
	/// <returns>The to move.</returns>
	/// <param name="nextMovement">Next movement.</param>
	/// <param name="direction">Direction.</param>
	private IEnumerator WaitToMove(EnemyMovement nextMovement, Vector2 nextDirection)
	{
		currentMovement = nextMovement;
		direction = Vector2.zero;

		timer = waitingToMove;
		while (timer > 0)
		{
			timer -= Time.deltaTime;

			yield return 0;
		}

		direction = nextDirection;
	}

	/// <summary>
	/// Executes the before born.
	/// </summary>
	protected override void ExecuteBeforeBorn ()
	{
		currentMovement = EnemyMovement.Up;
		direction = transform.up;
	}

	#endregion
}