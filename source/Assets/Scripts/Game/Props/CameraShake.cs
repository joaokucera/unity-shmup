using UnityEngine;
using System.Collections;

/// <summary>
/// A script to shake the camera.
/// </summary>
[RequireComponent(typeof(Camera))]
public class CameraShake : BaseScript
{
    #region [ FIELDS ]

    /// <summary>
    /// Singleton.
    /// </summary>
    private static CameraShake instance;
	/// <summary>
	/// The main camera.
	/// </summary>
	private Camera mainCamera;
    /// <summary>
    /// Original position.
    /// </summary>
    private Vector3 originPosition;
    /// <summary>
    /// Original rotation.
    /// </summary>
    private Quaternion originRotation;
    /// <summary>
    /// Shake variables.
    /// </summary>
	private float shakeIntensity = 0;
	/// <summary>
	/// The shake decay.
	/// </summary>
	[SerializeField]
    private float shakeDecay = 0.001f;
	/// <summary>
	/// The shake coef intensity.
	/// </summary>
	[SerializeField]
    private float shakeCoefIntensity = 0.01f;

    #endregion

	#region [ PROPERTIES ]

	/// <summary>
	/// Gets the instance.
	/// </summary>
	/// <value>The instance.</value>
	public static CameraShake Instance 
	{
		get
		{
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<CameraShake>();
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
		if (instance == null)
		{
			instance = this;
		}

		mainCamera = Camera.main;

		originPosition = mainCamera.transform.position;
		originRotation = mainCamera.transform.rotation;
	}

    /// <summary>
    /// Start to shake.
    /// </summary>
    public void Shake()
    {
        shakeIntensity = shakeCoefIntensity;

		StartCoroutine (UpdateShake ());
    }

	/// <summary>
	/// Shakes the update.
	/// </summary>
	/// <returns>The update.</returns>
	private IEnumerator UpdateShake()
	{
		/// When shake intensity is bigger than zero.
		while (shakeIntensity > 0)
		{
			mainCamera.transform.position = originPosition + Random.insideUnitSphere * shakeIntensity;
			
			mainCamera.transform.rotation = new Quaternion
			(
				originRotation.x + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
				originRotation.y + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
				originRotation.z + Random.Range(-shakeIntensity, shakeIntensity) * .2f,
				originRotation.w + Random.Range(-shakeIntensity, shakeIntensity) * .2f
			);
			
			shakeIntensity -= shakeDecay;

			yield return 0;
		}

		mainCamera.transform.position = originPosition;
		mainCamera.transform.rotation = originRotation;
	}

    #endregion
}