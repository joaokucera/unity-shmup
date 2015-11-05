using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyHealth))]
public class EnemyHealthEditor : BaseHealthEditor {

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
		
		instance.Update ();

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}
