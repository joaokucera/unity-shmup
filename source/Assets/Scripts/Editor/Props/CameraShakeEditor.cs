using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraShake))]
public class CameraShakeEditor : BaseEditor {

	#region [ FIELDS ]
	
	private SerializedProperty shakeDecay;
	private SerializedProperty shakeCoefIntensity;
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		shakeDecay = instance.FindProperty ("shakeDecay");
		shakeCoefIntensity = instance.FindProperty ("shakeCoefIntensity");
	}
	
	public override void OnInspectorGUI ()
	{
		instance.Update ();
		
		GUILayout.Space (10f);
		EditorGUILayout.Slider(shakeDecay, 0.001f, 0.01f, "Shake Decay");
		EditorGUILayout.LabelField("(how much decay each frame)",EditorStyles.miniLabel);
		
		GUILayout.Space (5f);
		EditorGUILayout.Slider(shakeCoefIntensity, 0.01f, 0.1f, "Shake Coef Intensity");
		EditorGUILayout.LabelField("(the intensity of shake)",EditorStyles.miniLabel);
		
		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}