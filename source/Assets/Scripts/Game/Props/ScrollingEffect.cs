using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

/// <summary>
/// A script to create a scrolling effect.
/// </summary>
public class ScrollingEffect : BaseScript 
{
	#region [ FIELDS ]

	/// <summary>
	/// The speed.
	/// </summary>
	[SerializeField]
	private float speed;
	/// <summary>
	/// The rects.
	/// </summary>
	[SerializeField]
	private List<Transform> rects = new List<Transform>();

	#endregion

	#region [ METHODS ]

	protected override void Update ()
	{
		rects.ForEach(r => 
        {
			r.Translate(-Vector3.up * speed * Time.deltaTime);
		});
	
		Transform firstChild = rects.FirstOrDefault ();

		if (firstChild != null)
		{
			Vector2 firstSize = firstChild.renderer.bounds.size;
			if ((firstChild.position.y + firstSize.y / 2f)  < -GlobalVariables.WorldSize.y)
			{
				if (!firstChild.renderer.isVisible)
				{
					Transform lastChild = rects.LastOrDefault ();

					Vector3 lastPosition = lastChild.position;
					Vector3 lastSize = lastChild.renderer.bounds.max - lastChild.renderer.bounds.min;

					firstChild.position = new Vector3(firstChild.position.x,
					                                  lastPosition.y + lastSize.y,
					                                  firstChild.position.z);

					rects.Remove(firstChild);
					rects.Add(firstChild);
				}
			}
		}
	}

	#endregion
}