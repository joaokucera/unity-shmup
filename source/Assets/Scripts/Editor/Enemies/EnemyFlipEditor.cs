using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyFlip))]
public class EnemyFlipEditor : BaseEnemyEditor 
{
	#region [ FIELDS ]
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
	}
	
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
	}
	
	#endregion
}