using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyPooling))]
public class EnemyPoolingEditor : GenericPoolingEditor 
{
	#region [ FIELDS ]
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
	}
	
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();

		instance.Update ();

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}