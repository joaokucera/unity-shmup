using UnityEngine;
using System.Collections;

/// <summary>
/// A specialization class to control pool of UI feedbacks.
/// </summary>
public class FeedbackPooling : GenericPooling 
{
	#region [ FIELDS ]
	
	/// <summary>
	/// The instance.
	/// </summary>
	private static FeedbackPooling instance;
	
	#endregion
	
	#region [ PROPERTIES ]
	
	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static FeedbackPooling Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<FeedbackPooling>();
			}
			
			return instance;
		}
	}
	
	#endregion
	
	#region [ METHODS ]

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		Parent = transform;

		base.Start ();
	}

	/// <summary>
	/// Show the specified position and text.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="text">Text.</param>
	public void Show (Vector3 position, string text)
	{
		GameObject newPoint = GetObjectFromPool (position) as GameObject;
		newPoint.transform.localScale = Vector3.one;

		newPoint.SendMessage ("Show", text);
	}
	
	#endregion
}