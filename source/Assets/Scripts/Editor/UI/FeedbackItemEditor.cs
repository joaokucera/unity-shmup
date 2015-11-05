using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FeedbackItem))]
public class FeedbackItemEditor : BaseEditor 
{
	#region [ FIELDS ]

	private SerializedProperty pointsTextUI;

	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();

		pointsTextUI = instance.FindProperty ("pointsTextUI");
	}
	
	public override void OnInspectorGUI ()
	{
		instance.Update ();

		GUILayout.Space(10f);
		EditorGUILayout.PropertyField(pointsTextUI);

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}