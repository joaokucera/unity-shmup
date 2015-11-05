using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyRear))]
public class EnemyRearEditor : BaseEnemyEditor 
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