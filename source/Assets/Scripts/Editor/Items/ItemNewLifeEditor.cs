using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemNewLife))]
public class ItemNewLifeEditor : BaseItemEditor 
{
	#region [ FIELDS ]
	
	private SerializedProperty gainLife;
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		gainLife = instance.FindProperty ("gainLife");
	}
	
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
		
		instance.Update ();
		
		GUILayout.Space (5f);
		EditorGUILayout.IntSlider(gainLife, 0, 3, "Gain Life");
		EditorGUILayout.LabelField("(how many lifes to gain)", EditorStyles.miniLabel);
		
		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}