using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// An abstract class to be a reference for any other health classes.
/// </summary>
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseHealth : BaseScript
{
    #region [ FIELDS ]
	
	/// <summary>
	/// The owner tag.
	/// </summary>
	protected AttackTag hitAgainstAttackTag;
	/// <summary>
	/// The was hit.
	/// </summary>
	protected bool wasHit = false;
	/// <summary>
	/// The extra lives.
	/// </summary>
	[SerializeField]
	protected int extraLives = 1;
	/// <summary>
	/// The current lives.
	/// </summary>
	protected int currentLives;
	/// <summary>
	/// The initial blink effect time.
	/// </summary>
	[SerializeField]
	protected float initialBlinkEffectTime = 0.2f;
	/// <summary>
	/// The blink effect time.
	/// </summary>
	protected float blinkEffectTime;
	/// <summary>
	/// The recovering time.
	/// </summary>
	[SerializeField]
	protected float recoveryTime = 1.5f;
    
    #endregion

	#region [ PROPERTIES ]

	#endregion

    #region [ METHODS ]

    /// <summary>
    /// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
    /// </summary>
	protected override void Start ()
    {
		currentLives = extraLives;

		blinkEffectTime = initialBlinkEffectTime;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
	protected override void Update ()
    {
        if (wasHit)
        {
            blinkEffectTime -= Time.deltaTime;

			if (blinkEffectTime < 0)
            {
                blinkEffectTime = initialBlinkEffectTime;

                OnBlink();
            }
        }
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this object (2D physics only).
    /// </summary>
    /// <param name="collider">Collider.</param>
	protected override void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.CompareTag(hitAgainstAttackTag.ToString()))
        {
			CameraShake.Instance.Shake ();

            BaseAmmo shot = collider.GetComponent<BaseAmmo>();
            RemoveLife(shot.Damage);

            shot.Active = false;
        }
    }

	/// <summary>
	/// Adds the life.
	/// </summary>
	/// <param name="gain">Gain.</param>
	public virtual void AddLife(int gain)
	{
		currentLives += gain;
	}

    /// <summary>
    /// Removes the life.
    /// </summary>
    /// <param name="loss">Loss.</param>
    public virtual void RemoveLife(int loss)
    {
        currentLives -= loss;

		if (currentLives < 0)
		{	
			ExplosionPooling.Instance.Show(transform.position, transform.rotation);
			SoundEffectControl.Instance.PlaySound(SoundEffectClip.Explosion);

            OnDeath();
        }
		else
		{
			OnHit ();
		}
    }
	
	/// <summary>
	/// Raises the hit event.
	/// </summary>
	protected void OnHit()
	{
		wasHit = true;

		Invoke("OnRecover", recoveryTime);
	}

	/// <summary>
	/// Raises the recover event.
	/// </summary>
	protected virtual void OnRecover()
	{
		wasHit = false;
	}

	/// <summary>
	/// Raises the death event.
	/// </summary>
	protected abstract void OnDeath();

    /// <summary>
    /// Raises the blink event.
    /// </summary>
    protected abstract void OnBlink();

    #endregion
}