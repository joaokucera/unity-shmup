using UnityEngine;
using System.Collections;

/// <summary>
/// A script to control player's inputs.
/// </summary>
public static class InputControl
{
	#region [ METHODS ]
	
    /// <summary>
    /// Gets a value indicating is shot enabled.
    /// </summary>
    /// <value><c>true</c> if is shot enabled; otherwise, <c>false</c>.</value>
    public static bool IsShotEnabled
    {
        get
        {
            return Input.GetButton(ShortcutWords.ShotEnabled);
        }
    }

    /// <summary>
    /// Gets the movement.
    /// </summary>
    /// <returns>The movement.</returns>
    public static Vector2 GetMovement()
    {
        var movement = new Vector2
        (
            Input.GetAxis(ShortcutWords.HorizontalMovement),
            Input.GetAxis(ShortcutWords.VerticalMovement)
        );

		return movement.normalized;
    }

	#endregion
}