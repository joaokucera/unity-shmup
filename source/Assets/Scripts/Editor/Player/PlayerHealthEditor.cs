using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerHealth))]
public class PlayerHealthEditor : BaseHealthEditor {

	#region [ FIELDS ]
	
	private SerializedProperty damageHitAgainstEnemies;

	#endregion

	#region [ METHODS ]

	protected override void OnEnable ()
	{
		base.OnEnable ();

		damageHitAgainstEnemies = instance.FindProperty ("damageHitAgainstEnemies");
	}

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		instance.Update ();

		GUILayout.Space (5f);
		EditorGUILayout.IntSlider(damageHitAgainstEnemies, 1, 10, "Damage Against Enemies");
		EditorGUILayout.LabelField("(the damage when was hit by an enemy)",EditorStyles.miniLabel);

		instance.ApplyModifiedProperties ();
	}

	#endregion
}