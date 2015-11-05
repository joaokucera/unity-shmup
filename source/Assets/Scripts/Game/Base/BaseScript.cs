using UnityEngine;
using System.Collections;

/// <summary>
/// A base script to hold all unity events and provide me a better way to call these events.
/// </summary>
public class BaseScript : MonoBehaviour 
{
	#region [ METHODS ]

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	protected virtual void Awake()
	{
	}
	/// <summary>
	/// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// </summary>
	protected virtual void FixedUpdate()
	{
	}
	/// <summary>
	/// LateUpdate is called every frame, if the Behaviour is enabled.
	/// </summary>
	protected virtual void LateUpdate()
	{
	}
	/// <summary>
	/// Sent to all game objects when the player pauses.
	/// </summary>
	protected virtual void OnApplicationPause()
	{
	}
	/// <summary>
	/// Sent to all game objects before the application is quit.
	/// </summary>
	protected virtual void OnApplicationQuit()
	{
	}
	/// <summary>
	/// OnBecameInvisible is called when the renderer is no longer visible by any camera.
	/// </summary>
	protected virtual void OnBecameInvisible()
	{
	}
	/// <summary>
	/// OnBecameVisible is called when the renderer became visible by any camera.
	/// </summary>
	protected virtual void OnBecameVisible()
	{
	}
	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
	/// </summary>
	protected virtual void OnCollisionEnter(Collision collision)
	{
	}
	/// <summary>
	/// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	/// </summary>
	protected virtual void OnCollisionEnter2D(Collision2D collision)
	{
	}
	/// <summary>
	/// OnCollisionExit is called when this collider/rigidbody has stopped touching another rigidbody/collider.
	/// </summary>
	protected virtual void OnCollisionExit(Collision collision)
	{
	}
	/// <summary>
	/// Sent when a collider on another object stops touching this object's collider (2D physics only).
	/// </summary>
	protected virtual void OnCollisionExit2D(Collision2D collision)
	{
	}
	/// <summary>
	/// OnCollisionStay is called once per frame for every collider/rigidbody that is touching rigidbody/collider.
	/// </summary>
	protected virtual void OnCollisionStay(Collision collision)
	{
	}
	/// <summary>
	/// Sent each frame where a collider on another object is touching this object's collider (2D physics only).
	/// </summary>
	protected virtual void OnCollisionStay2D(Collision2D collision)
	{
	}
	/// <summary>
	/// This function is called when the MonoBehaviour will be destroyed.
	/// </summary>
	protected virtual void OnDestroy()
	{
	}
	/// <summary>
	/// This function is called when the behaviour becomes disabled () or inactive.
	/// </summary>
	protected virtual void OnDisable()
	{
	}
	/// <summary>
	/// Implement OnDrawGizmos if you want to draw gizmos that are also pickable and always drawn.
	/// </summary>
	protected virtual void OnDrawGizmos()
	{
	}
	/// <summary>
	/// Implement this OnDrawGizmosSelected if you want to draw gizmos only if the object is selected.
	/// </summary>
	protected virtual void OnDrawGizmosSelected()
	{
	}
	/// <summary>
	/// This function is called when the object becomes enabled and active.
	/// </summary>
	protected virtual void OnEnable()
	{
	}
	/// <summary>
	/// OnGUI is called for rendering and handling GUI events.
	/// </summary>
	protected virtual void OnGUI()
	{
	}
	/// <summary>
	/// This function is called after a new level was loaded.
	/// </summary>
	protected virtual void OnLevelWasLoaded()
	{
	}
	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while over the GUIElement or Collider.
	/// </summary>
	protected virtual void OnMouseDown()
	{
	}
	/// <summary>
	/// OnMouseDrag is called when the user has clicked on a GUIElement or Collider and is still holding down the mouse.
	/// </summary>
	protected virtual void OnMouseDrag()
	{
	}
	/// <summary>
	/// OnMouseEnter is called when the mouse entered the GUIElement or Collider.
	/// </summary>
	protected virtual void OnMouseEnter()
	{
	}
	/// <summary>
	/// OnMouseExit is called when the mouse is not any longer over the GUIElement or Collider.
	/// </summary>
	protected virtual void OnMouseExit()
	{
	}
	/// <summary>
	/// OnMouseOver is called every frame while the mouse is over the GUIElement or Collider.
	/// </summary>
	protected virtual void OnMouseOver()
	{
	}
	/// <summary>
	/// OnMouseUp is called when the user has released the mouse button.
	/// </summary>
	protected virtual void OnMouseUp()
	{
	}
	/// <summary>
	/// OnMouseUpAsButton is only called when the mouse is released over the same GUIElement or Collider as it was pressed.
	/// </summary>
	protected virtual void OnMouseUpAsButton()
	{
	}
	/// <summary>
	/// OnParticleCollision is called when a particle hits a collider.
	/// </summary>
	protected virtual void OnParticleCollision()
	{
	}
	/// <summary>
	/// OnPostRender is called after a camera finished rendering the scene.
	/// </summary>
	protected virtual void OnPostRender()
	{
	}
	/// <summary>
	/// OnPreCull is called before a camera culls the scene.
	/// </summary>
	protected virtual void OnPreCull()
	{
	}
	/// <summary>
	/// OnPreRender is called before a camera starts rendering the scene.
	/// </summary>
	protected virtual void OnPreRender()
	{
	}
	/// <summary>
	/// OnRenderImage is called after all rendering is complete to render image.
	/// </summary>
	protected virtual void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
	}
	/// <summary>
	/// OnRenderObject is called after camera has rendered the scene.
	/// </summary>
	protected virtual void OnRenderObject()
	{
	}
	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	protected virtual void OnTriggerEnter(Collider collider)
	{
	}
	/// <summary>
	/// Sent when another object enters a trigger collider attached to this object (2D physics only).
	/// </summary>
	protected virtual void OnTriggerEnter2D(Collider2D collider)
	{
	}
	/// <summary>
	/// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	/// </summary>
	protected virtual void OnTriggerExit(Collider collider)
	{
	}
	/// <summary>
	/// Sent when another object leaves a trigger collider attached to this object (2D physics only).
	/// </summary>
	protected virtual void OnTriggerExit2D(Collider2D collider)
	{
	}
	/// <summary>
	/// OnTriggerStay is called once per frame for every Collider other that is touching the trigger.
	/// </summary>
	protected virtual void OnTriggerStay(Collider collider)
	{
	}
	/// <summary>
	/// Sent each frame where another object is within a trigger collider attached to this object (2D physics only).
	/// </summary>
	protected virtual void OnTriggerStay2D(Collider2D collider)
	{
	}
	/// <summary>
	/// This function is called when the script is loaded or a value is changed in the inspector (Called in the editor only).
	/// </summary>
	protected virtual void OnValidate()
	{
	}
	/// <summary>
	/// OnWillRenderObject is called once for each camera if the object is visible.
	/// </summary>
	protected virtual void OnWillRenderObject()
	{
	}
	/// <summary>
	/// Reset to default values.
	/// </summary>
	protected virtual void Reset()
	{
	}
	/// <summary>
	/// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	/// </summary>
	protected virtual void Start()
	{
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	protected virtual void Update()
	{
	}

	#endregion
}