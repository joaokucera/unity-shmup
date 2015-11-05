using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyAcrobatic))]
public class EnemyAcrobaticEditor : BaseEnemyEditor 
{
	#region [ FIELDS ]
	
	private SerializedProperty movement;
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		movement = instance.FindProperty ("movement");
	}
	
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
		
		instance.Update ();
		
		GUILayout.Space (5f);
		EditorGUILayout.PropertyField(movement);
		EditorGUILayout.LabelField("(the movement side behaviour)", EditorStyles.miniLabel);
		
		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}