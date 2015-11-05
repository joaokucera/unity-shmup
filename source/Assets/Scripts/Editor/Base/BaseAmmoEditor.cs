using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseAmmo))]
public class BaseAmmoEditor : BaseEditor {
	
	#region [ FIELDS ]
	
	private SerializedProperty damage;
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		damage = instance.FindProperty ("damage");
	}
	
	public override void OnInspectorGUI ()
	{
		instance.Update ();
		
		GUILayout.Space (10f);
		
		EditorGUILayout.IntSlider(damage, 1, 5, "Damage");
		EditorGUILayout.LabelField("(damage value)",EditorStyles.miniLabel);
		
		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}
