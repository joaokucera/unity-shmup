using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseHealth))]
public abstract class BaseHealthEditor : BaseEditor 
{	
	#region [ FIELDS ]
	
	private SerializedProperty extraLives;
	private SerializedProperty initialBlinkEffectTime;
	private SerializedProperty recoveryTime;
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		extraLives = instance.FindProperty ("extraLives");
		initialBlinkEffectTime = instance.FindProperty ("initialBlinkEffectTime");
		recoveryTime = instance.FindProperty ("recoveryTime");
	}
	
	public override void OnInspectorGUI ()
	{
		instance.Update ();
		
		GUILayout.Space (10f);
		EditorGUILayout.IntSlider(extraLives, 0, 10, "Extra Lives");
		EditorGUILayout.LabelField("(extra lives value)",EditorStyles.miniLabel);
		
		GUILayout.Space (5f);
		EditorGUILayout.Slider(initialBlinkEffectTime, 0.1f, 1f, "Blink Effect Time");
		EditorGUILayout.LabelField("(how long is the effect)",EditorStyles.miniLabel);
		
		GUILayout.Space (5f);
		EditorGUILayout.Slider(recoveryTime, 0f, 2.5f, "Recovery Time");
		EditorGUILayout.LabelField("(how long to recover and be hit again)",EditorStyles.miniLabel);
		
		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}