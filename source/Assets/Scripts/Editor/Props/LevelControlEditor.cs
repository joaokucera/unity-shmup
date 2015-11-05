using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelControl))]
public class LevelControlEditor : BaseEditor
{
	#region [ FIELDS ]
	
	private SerializedProperty timeToNextStage;
	private SerializedProperty minTimeToSpawn;
	private SerializedProperty maxTimeToSpawn;
	private SerializedProperty valueToDecrementFromTimeToSpawn;
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		timeToNextStage = instance.FindProperty ("timeToNextStage");
		minTimeToSpawn = instance.FindProperty ("minTimeToSpawn");
		maxTimeToSpawn = instance.FindProperty ("maxTimeToSpawn");
		valueToDecrementFromTimeToSpawn = instance.FindProperty ("valueToDecrementFromTimeToSpawn");
	}
	
	public override void OnInspectorGUI()
	{
		instance.Update ();
		
		GUILayout.Space(10f);
		EditorGUILayout.Slider(timeToNextStage, 30f, 120f, "Time to next stage");
		EditorGUILayout.LabelField("(the stage time)",EditorStyles.miniLabel);
		
		GUILayout.Space(5f);
		GUILayout.Label ("Time To Spawn Enemies Settings", EditorStyles.boldLabel); 
		EditorGUILayout.Slider(minTimeToSpawn, 1f, 5f, "Minimum");
		EditorGUILayout.Slider(maxTimeToSpawn, 3f, 7f, "Maximum");
		EditorGUILayout.Slider(valueToDecrementFromTimeToSpawn, 0.1f, 1f, "Value to decrement");
		EditorGUILayout.LabelField("(value to reduce the maximum and minimum values after each stage)", EditorStyles.miniLabel);
		
		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}