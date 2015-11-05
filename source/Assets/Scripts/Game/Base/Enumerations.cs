/// <summary>
/// Owner attack tag.
/// </summary>
public enum AttackTag
{
	PlayerAttack,
	EnemyAttack
}

/// <summary>
/// Player gun.
/// </summary>
public enum PlayerGun
{
	Front = 0,
	Front_Left = 1,
	Front_Right = 2,
	Left_Angle = 3,
	Right_Angle = 4,
	Left = 5,
	Right = 6,
	Back = 7
}

/// <summary>
/// Enemy movement.
/// </summary>
public enum EnemyMovement
{
	Up = 0,
	Down = 1,
	Left = 2,
	Right = 3
}

/// <summary>
/// Level state.
/// </summary>
public enum LevelState
{
	Begin,
	Playing,
	Interlude,
	GameOver
}

/// <summary>
/// Enemy type.
/// </summary>
public enum EnemyType
{
	Acrobatic = 0,
	Big = 1,
	Cargo = 2,
	Flip = 3,
	Ordinary = 4,
	Rear = 5,
	Turn = 6,
}

/// <summary>
/// Sound effect clip.
/// </summary>
public enum SoundEffectClip
{
	ButtonClick,
	CollectingItem,
	GameOver,
	PlayerShot,
	StageCompleted,
	Explosion
}