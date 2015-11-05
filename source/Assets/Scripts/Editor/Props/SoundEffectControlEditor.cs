using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SoundEffectControl))]
public class SoundEffectControlEditor : BaseEditor
{
	#region [ FIELDS ]

	private SerializedProperty buttonClickClip;
	private SerializedProperty collectingItemClip;
	private SerializedProperty gameOverClip;
	private SerializedProperty playerShotClip;
	private SerializedProperty stageCompletedClip;
	private SerializedProperty explosionClip;

	private SerializedProperty musicSource;

	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();

		buttonClickClip = instance.FindProperty ("buttonClickClip");
		collectingItemClip = instance.FindProperty ("collectingItemClip");
		gameOverClip = instance.FindProperty ("gameOverClip");
		playerShotClip = instance.FindProperty ("playerShotClip");
		stageCompletedClip = instance.FindProperty ("stageCompletedClip");
		explosionClip = instance.FindProperty ("explosionClip");

		musicSource = instance.FindProperty ("musicSource");
	}
	
	public override void OnInspectorGUI()
	{
		instance.Update ();

		GUILayout.Space(10f);
		GUILayout.Label ("Sound Effect Clips", EditorStyles.boldLabel); 
		EditorGUILayout.PropertyField(buttonClickClip);
		EditorGUILayout.PropertyField(collectingItemClip);
		EditorGUILayout.PropertyField(gameOverClip);
		EditorGUILayout.PropertyField(playerShotClip);
		EditorGUILayout.PropertyField(stageCompletedClip);
		EditorGUILayout.PropertyField(explosionClip);

		GUILayout.Space(10f);
		EditorGUILayout.PropertyField(musicSource);
		EditorGUILayout.LabelField("(the audio source to environment music)", EditorStyles.miniLabel);
		
		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}