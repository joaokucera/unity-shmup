using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Game over screen class.
/// </summary>
public class GameOverControl : MenuControl 
{
	#region [ METHODS ]

	/// <summary>
	/// Level this instance.
	/// </summary>
	public override void Level ()
	{	
		SaveScore ();
		ButtonClick ();
			
		Application.LoadLevel ("Level");
	}

	/// <summary>
	/// Menu this instance.
	/// </summary>
	public override void Menu ()
	{
		SaveScore ();
		ButtonClick ();

		Destroy(SoundEffectControl.Instance);

		Application.LoadLevel ("Menu");
	}
	
	/// <summary>
	/// Saves the score.
	/// </summary>
	private void SaveScore ()
	{
		GlobalVariables.HUDControl.SaveNewPlayerScore ();
	}

	#endregion
}