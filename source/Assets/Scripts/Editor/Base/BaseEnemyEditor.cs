using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseEnemy))]
public abstract class BaseEnemyEditor : BaseEditor {

	#region [ FIELDS ]
	
	private SerializedProperty points;
	private SerializedProperty speed;

	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();

		points = instance.FindProperty ("points");
		speed = instance.FindProperty ("speed");
	}
	
	public override void OnInspectorGUI ()
	{
		instance.Update ();

		GUILayout.Space (10f);
		EditorGUILayout.IntSlider(points, 1, 1000, "Points");
		EditorGUILayout.LabelField("(points by destroying)", EditorStyles.miniLabel);

		GUILayout.Space (5f);
		EditorGUILayout.Slider(speed, 1f, 1000f, "Speed");
		EditorGUILayout.LabelField("(enemy speed)", EditorStyles.miniLabel);

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}
