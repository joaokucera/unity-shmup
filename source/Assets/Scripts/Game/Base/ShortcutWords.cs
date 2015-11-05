using UnityEngine;
using System.Collections;

/// <summary>
/// A central point of constants values used by unity as axes and tags.
/// </summary>
public static class ShortcutWords
{
    #region [ TAGS ]

    /// <summary>
    /// Player tag.
    /// </summary>
    public const string PlayerTag = "Player";
    /// <summary>
    /// Enemy shot tag.
    /// </summary>
    public const string PlayerAttackTag = "PlayerAttack";
    /// <summary>
    /// Enemy tag.
    /// </summary>
    public const string EnemyTag = "Enemy";
    /// <summary>
    /// Enemy shot tag.
    /// </summary>
    public const string EnemyAttackTag = "EnemyAttack";
    /// <summary>
    /// Item tag.
    /// </summary>
    public const string ItemTag = "Item";
	/// <summary>
	/// The name of the pooling repository.
	/// </summary>
	public const string PoolingTag = "Pooling";

    #endregion

    #region [ AXES ]

    /// <summary>
    /// Horizontal input axis.
    /// </summary>
    public const string HorizontalMovement = "Horizontal";
    /// <summary>
    /// Vertical input axis.
    /// </summary>
    public const string VerticalMovement = "Vertical";
    /// <summary>
    /// The shot enabled.
    /// </summary>
    public const string ShotEnabled = "Fire1";

    #endregion
}