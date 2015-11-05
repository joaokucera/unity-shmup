using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PauseControl))]
public class PauseControlEditor : BaseEditor 
{
	#region [ FIELDS ]

	private SerializedProperty pauseButton;
	private SerializedProperty playButton;
	private SerializedProperty reloadButton;

	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();

		pauseButton = instance.FindProperty ("pauseButton");
		playButton = instance.FindProperty ("playButton");
		reloadButton = instance.FindProperty ("reloadButton");
	}
	
	public override void OnInspectorGUI()
	{
		instance.Update ();

		GUILayout.Space(10f);
		EditorGUILayout.PropertyField(pauseButton);

		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(playButton);

		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(reloadButton);

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}