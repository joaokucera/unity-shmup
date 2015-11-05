using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyTurn))]
public class EnemyTurnEditor : BaseEnemyEditor 
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