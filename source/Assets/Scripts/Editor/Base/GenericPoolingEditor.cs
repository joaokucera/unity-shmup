using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GenericPooling))]
public class GenericPoolingEditor : BaseEditor {
	
	#region [ FIELDS ]
	
	private SerializedProperty prefab;
	private SerializedProperty poolSize;
	private SerializedProperty poolCanGrow;

	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		prefab = instance.FindProperty ("prefab");
		poolSize = instance.FindProperty ("poolSize");
		poolCanGrow = instance.FindProperty ("poolCanGrow");
	}
	
	public override void OnInspectorGUI()
	{
		instance.Update ();
		
		GUILayout.Space (10f);
		GUILayout.Label ("Pooling Settings", EditorStyles.boldLabel);
		EditorGUILayout.PropertyField (prefab);
		EditorGUILayout.IntSlider(poolSize, 1, 10, "Pool Size");
		EditorGUILayout.BeginHorizontal();
		poolCanGrow.boolValue = EditorGUILayout.Toggle ("Pool Can Grow Enabled", poolCanGrow.boolValue);
		EditorGUILayout.LabelField("(whether the pool can grow as demand)",EditorStyles.miniLabel);
		EditorGUILayout.EndHorizontal();
		
		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}