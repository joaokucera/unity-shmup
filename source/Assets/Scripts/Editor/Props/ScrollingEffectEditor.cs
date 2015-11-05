using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScrollingEffect))]
public class ScrollingEffectEditor : BaseEditor
{
	#region [ FIELDS ]
	
	private SerializedProperty rects;

	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		rects = instance.FindProperty ("rects");
	}
	
	public override void OnInspectorGUI()
	{
		instance.Update ();
		
		GUILayout.Space(10f);
		EditorGUILayout.PropertyField(rects, true);
		EditorGUILayout.LabelField("(the scrolling parts)", EditorStyles.miniLabel);
		
		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}