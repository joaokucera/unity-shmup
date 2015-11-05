using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerWeapon))]
public class PlayerWeaponEditor : GenericPoolingEditor 
{
	#region [ FIELDS ]
	
	private SerializedProperty shotSpeed;
	private SerializedProperty weaponRate;
	private SerializedProperty guns;
	
	#endregion

	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();

		shotSpeed = instance.FindProperty ("shotSpeed");
		weaponRate = instance.FindProperty ("weaponRate");
		guns = instance.FindProperty ("guns");
	}
	
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI ();

		instance.Update ();

		GUILayout.Space(5f);
		GUILayout.Label ("Shot Settings", EditorStyles.boldLabel); 
		EditorGUILayout.Slider(shotSpeed, 500f, 2000f, "Shot Speed");

		GUILayout.Space(5f);
		GUILayout.Label ("Weapon Rate", EditorStyles.boldLabel); 
		EditorGUILayout.Slider(weaponRate, 0.1f, 1.0f, "Weapon Rate");

		GUILayout.Space(5f);
		GUILayout.Label ("Guns", EditorStyles.boldLabel); 
		EditorGUILayout.PropertyField(guns, true);

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}