using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A script to centralize all sound effects and musics.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SoundEffectControl : BaseScript 
{
	#region [ FIELDS ]

	/// <summary>
	/// The instance.
	/// </summary>
	private static SoundEffectControl instance;

	/// <summary>
	/// The button click clip.
	/// </summary>
	[SerializeField]
	private AudioClip buttonClickClip;
	/// <summary>
	/// The collecting item clip.
	/// </summary>
	[SerializeField]
	private AudioClip collectingItemClip;
	/// <summary>
	/// The game over clip.
	/// </summary>
	[SerializeField]
	private AudioClip gameOverClip;
	/// <summary>
	/// The player shot clip.
	/// </summary>
	[SerializeField]
	private AudioClip playerShotClip;
	/// <summary>
	/// The stage completed clip.
	/// </summary>
	[SerializeField]
	private AudioClip stageCompletedClip;
	/// <summary>
	/// The explosion clip.
	/// </summary>
	[SerializeField]
	private AudioClip explosionClip;

	/// <summary>
	/// The clip dictionary.
	/// </summary>
	private Dictionary<SoundEffectClip, AudioClip> clipDictionary;
	/// <summary>
	/// The music source.
	/// </summary>
	[SerializeField]
	private AudioSource musicSource;

	#endregion

	#region [ PROPERTIES ]

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static SoundEffectControl Instance
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<SoundEffectControl>();
			}
			
			return instance;
		}
	}

	#endregion

	#region [ METHODS ]

	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected override void Start()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this);

			StartCoroutine (PlayMusic ());
			CreateDictionary();
		}
		else
		{
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// Shows the game over panel.
	/// </summary>
	/// <returns>The game over panel.</returns>
	private IEnumerator PlayMusic()
	{
		musicSource.volume = 0f;
		musicSource.Play();
		
		while (musicSource.volume < 0.5f)
		{
			musicSource.volume += Time.deltaTime / 10f;
			
			yield return 0;
		}
	}

	/// <summary>
	/// Continues the music.
	/// </summary>
	public void ContinueMusic()
	{
		//StartCoroutine (PlayMusic ());
		musicSource.Play ();
	}

	/// <summary>
	/// Plaies the sound.
	/// </summary>
	/// <param name="soundEffectClip">Sound effect clip.</param>
	public void PlaySound(SoundEffectClip soundEffectClip)
	{
		if (soundEffectClip == SoundEffectClip.GameOver)
		{
			musicSource.Stop();
		}
		else if (soundEffectClip == SoundEffectClip.StageCompleted)
		{
			musicSource.Pause();
		}

		AudioClip originalClip;
		
		if (clipDictionary.TryGetValue(soundEffectClip, out originalClip))
		{
			MakeSound(originalClip);
		}
	}

	/// <summary>
	/// Creates the dictionary.
	/// </summary>
	private void CreateDictionary()
	{
		clipDictionary = new Dictionary<SoundEffectClip, AudioClip>();

		clipDictionary.Add(SoundEffectClip.ButtonClick, buttonClickClip);
		clipDictionary.Add(SoundEffectClip.CollectingItem, collectingItemClip);
		clipDictionary.Add(SoundEffectClip.GameOver, gameOverClip);
		clipDictionary.Add(SoundEffectClip.PlayerShot, playerShotClip);
		clipDictionary.Add(SoundEffectClip.StageCompleted, stageCompletedClip);
		clipDictionary.Add(SoundEffectClip.Explosion, explosionClip);
	}

	/// <summary>
	/// Makes the sound.
	/// </summary>
	/// <param name="originalClip">Original clip.</param>
	private void MakeSound(AudioClip originalClip)
	{
		audio.PlayOneShot (originalClip);
	}

	#endregion
}