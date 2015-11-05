using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyOrdinary))]
public class EnemyOrdinaryEditor : BaseEnemyEditor 
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