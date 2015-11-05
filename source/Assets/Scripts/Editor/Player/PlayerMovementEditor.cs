using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerMovement))]
public class PlayerMovementEditor : BaseEditor {

	#region [ FIELDS ]
	
	private SerializedProperty movementSpeed;

	#endregion

	#region [ METHODS ]

	protected override void OnEnable ()
	{
		base.OnEnable ();

		movementSpeed = instance.FindProperty ("movementSpeed");
	}

	public override void OnInspectorGUI()
	{
		instance.Update ();

		GUILayout.Space (10f);
		EditorGUILayout.Slider(movementSpeed, 1f, 10f, "Movement Speed");
		EditorGUILayout.LabelField("(how fast to move)", EditorStyles.miniLabel);

		instance.ApplyModifiedProperties ();
	}

	#endregion
}