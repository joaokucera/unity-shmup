using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HighScoreControl))]
public class HighScoreControlEditor : BaseEditor 
{
	#region [ FIELDS ]

	private SerializedProperty highScoreContainer;
	private SerializedProperty playerHighScorePrefab;

	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();

		highScoreContainer = instance.FindProperty ("highScoreContainer");
		playerHighScorePrefab = instance.FindProperty ("playerHighScorePrefab");
	}
	
	public override void OnInspectorGUI()
	{
		instance.Update ();

		GUILayout.Space(10f);
		EditorGUILayout.PropertyField(highScoreContainer);

		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(playerHighScorePrefab);

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}