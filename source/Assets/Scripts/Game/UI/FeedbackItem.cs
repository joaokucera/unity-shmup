using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Controls each feedback UI effect.
/// </summary>
public class FeedbackItem : BaseScript 
{
	#region [ FIELDS ]

	/// <summary>
	/// The points text U.
	/// </summary>
	[SerializeField]
	private Text pointsTextUI;

	#endregion

	#region [ METHODS ]

	/// <summary>
	/// Show the specified text.
	/// </summary>
	/// <param name="text">Text.</param>
	public void Show (string text)
	{
		pointsTextUI.text = text;
		
		StartCoroutine (Up ());
	}

	/// <summary>
	/// Up this instance.
	/// </summary>
	private IEnumerator Up()
	{
		for (float timer = 1f; timer > 0; timer -= Time.deltaTime)
		{
			transform.Translate(Vector2.up * Time.deltaTime);

			yield return 0;
		}

		Hide ();
	}

	/// <summary>
	/// Hide this instance.
	/// </summary>
	public void Hide ()
	{
		pointsTextUI.text = string.Empty;

		gameObject.SetActive (false);
	}

	#endregion
}