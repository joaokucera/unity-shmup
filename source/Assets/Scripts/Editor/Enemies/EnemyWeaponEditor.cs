using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyWeapon))]
public class EnemyWeaponEditor : GenericPoolingEditor {

	#region [ FIELDS ]
	
	private SerializedProperty shotSpeed;
	private SerializedProperty weaponRate;
	
	#endregion

	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();

		shotSpeed = instance.FindProperty ("shotSpeed");
		weaponRate = instance.FindProperty ("weaponRate");
	}
	
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();

		instance.Update ();

		GUILayout.Space(5f);
		GUILayout.Label ("Shot Settings", EditorStyles.boldLabel); 
		EditorGUILayout.Slider(shotSpeed, 1f, 1000f, "Speed");

		GUILayout.Space(5f);
		GUILayout.Label ("Weapon Rate", EditorStyles.boldLabel); 
		EditorGUILayout.Slider(weaponRate, 0.1f, 10f, "Rate");

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}