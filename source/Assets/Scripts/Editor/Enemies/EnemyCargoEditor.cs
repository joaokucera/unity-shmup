using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyCargo))]
public class EnemyCargoEditor : BaseEnemyEditor 
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