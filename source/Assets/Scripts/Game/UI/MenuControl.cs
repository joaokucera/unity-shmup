using UnityEngine;
using System.Collections;

/// <summary>
/// A script to navigate among scenes.
/// </summary>
public class MenuControl : BaseScript 
{
	#region [ METHODS ]

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	protected override void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Application.loadedLevelName == "Menu")
			{
				Application.Quit();
			}
			else
			{
				Application.LoadLevel ("Menu");
			}
		}
	}

	/// <summary>
	/// Level this instance.
	/// </summary>
	public virtual void Level()
	{
		ButtonClick ();

		Destroy(SoundEffectControl.Instance);

		Application.LoadLevel ("Level");
	}

	/// <summary>
	/// Hows to play.
	/// </summary>
	public void HowToPlay()
	{
		ButtonClick ();

		Application.LoadLevel ("HowToPlay");
	}

	/// <summary>
	/// Highs the scores.
	/// </summary>
	public void HighScores()
	{
		ButtonClick ();

		Application.LoadLevel ("HighScores");
	}

	/// <summary>
	/// Menu this instance.
	/// </summary>
	public virtual void Menu()
	{
		ButtonClick ();

		Application.LoadLevel ("Menu");
	}

	/// <summary>
	/// Quit this instance.
	/// </summary>
	public void Quit()
	{
		ButtonClick ();
		
		Application.Quit ();
	}

	/// <summary>
	/// Buttons the click.
	/// </summary>
	protected void ButtonClick()
	{
		SoundEffectControl.Instance.PlaySound(SoundEffectClip.ButtonClick);
	}

	#endregion
}