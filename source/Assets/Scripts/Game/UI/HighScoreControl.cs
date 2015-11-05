using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// High score screen class.
/// </summary>
public class HighScoreControl : BaseScript 
{
	#region [ FIELDS ]

	/// <summary>
	/// The high score container.
	/// </summary>
	[SerializeField]
	private RectTransform highScoreContainer;

	/// <summary>
	/// The player high score prefab.
	/// </summary>
	[SerializeField]
	private Text playerHighScorePrefab;

	#endregion

	#region [ METHODS ]

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		List<PlayerScore> scores = HighScoreSystem.Instance.Scores;

		for (int i = 0; i < scores.Count; i++) 
		{
			Text child = Instantiate(playerHighScorePrefab) as Text;
			child.text = string.Format("{0}º) {1,-8} | {2}", (i + 1), scores[i].Name.ToUpper(), scores[i].Score);

			child.transform.SetParent(highScoreContainer);
		}
	}

	#endregion
}