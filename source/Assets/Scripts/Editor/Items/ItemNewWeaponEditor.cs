using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemNewWeapon))]
public class ItemNewWeaponEditor : BaseItemEditor 
{
	#region [ FIELDS ]
	
	private SerializedProperty gunsToActivate;
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		gunsToActivate = instance.FindProperty ("gunsToActivate");
	}
	
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
		
		instance.Update ();
		
		GUILayout.Space (5f);
		EditorGUILayout.PropertyField(gunsToActivate, true);
		EditorGUILayout.LabelField("(which guns will be activated)", EditorStyles.miniLabel);
		
		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}