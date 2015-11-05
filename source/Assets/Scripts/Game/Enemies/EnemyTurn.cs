using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy who comes from screen sides and turns to center.
/// </summary>
public class EnemyTurn : BaseEnemy 
{
	#region [ FIELDS ]

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
		if ((transform.position.y + boundSize.y) < -GlobalVariables.WorldSize.y)
		{
			ExecuteBeforeBorn();

			Active = false;

			return;
		}

		if (!turned)
		{
			Vector2 direction = -transform.up;

			if ((transform.position.y - boundSize.y / 2) < GlobalVariables.WorldSize.y / 2f)
			{
				if (transform.position.x > GlobalVariables.PlayerObject.transform.position.x)
				{
					StartCoroutine(Turning(-1));
				}
				else
				{
					StartCoroutine(Turning(1));
				}

				turned = true;
			}

			lastDirection = direction;
		}

		transform.Translate (lastDirection * speed * Time.deltaTime);
	}

	/// <summary>
	/// Turning this instance.
	/// </summary>
	private IEnumerator Turning(float side)
	{
		while (renderer.isVisible) 
		{
			transform.Rotate(new Vector3(0, 0, side * Time.deltaTime * 25f));
			
			yield return 0;
		}

		transform.rotation = originalRotation;
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