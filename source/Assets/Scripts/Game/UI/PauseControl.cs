using UnityEngine;
using System.Collections;

/// <summary>
/// Controls pause, play and reload actions.
/// </summary>
public class PauseControl : BaseScript 
{
	#region [ FIELDS ]

	/// <summary>
	/// The pause button.
	/// </summary>
	[SerializeField]
	private GameObject pauseButton = null, playButton = null, reloadButton = null;

	#endregion

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start ()
	{
		pauseButton.SetActive(true);
		playButton.SetActive(false);
		reloadButton.SetActive(false);
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	protected override void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.P))
		{
			PauseOrPlay();
		}
	}

	public void PauseOrPlay()
	{
		SoundEffectControl.Instance.PlaySound (SoundEffectClip.ButtonClick);

		GlobalVariables.Paused = !GlobalVariables.Paused;

		if (GlobalVariables.Paused)
		{
			ShowPlayAndReloadButtons();
		}
		else
		{
			HidePlayAndReloadButtons();
		}
	}

	public void Reload()
	{
		SoundEffectControl.Instance.PlaySound (SoundEffectClip.ButtonClick);

		GlobalVariables.Paused = false;

		Application.LoadLevel("Level");
	}
	
	public void HidePlayAndReloadButtons()
	{
		pauseButton.SetActive(true);
		playButton.SetActive(false);
		reloadButton.SetActive(false);
	}
	
	public void ShowPlayAndReloadButtons()
	{
		pauseButton.SetActive(false);
		playButton.SetActive(true);
		reloadButton.SetActive(true);
	}
}