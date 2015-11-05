using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HUDControl))]
public class HUDControlEditor : BaseEditor 
{
	#region [ FIELDS ]
	
	private SerializedProperty lifeGroup;
	private SerializedProperty lifeIconPrefab;
	private SerializedProperty scoreTextUI;
	private SerializedProperty highScoreTextUI;
	private SerializedProperty readyTextUI;
	private SerializedProperty stageTextUI;
	private SerializedProperty gameOverImageUI;
	private SerializedProperty gameOverAnimator;
	private SerializedProperty playerNameFieldUI;
	private SerializedProperty yourScoreTextUI;
	private SerializedProperty bestScoreTextUI;
	private SerializedProperty gunIconImageUI;
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		lifeGroup = instance.FindProperty ("lifeGroup");
		lifeIconPrefab = instance.FindProperty ("lifeIconPrefab");
		scoreTextUI = instance.FindProperty ("scoreTextUI");
		highScoreTextUI = instance.FindProperty ("highScoreTextUI");
		readyTextUI = instance.FindProperty ("readyTextUI");
		stageTextUI = instance.FindProperty ("stageTextUI");
		gameOverImageUI = instance.FindProperty ("gameOverImageUI");
		gameOverAnimator = instance.FindProperty ("gameOverAnimator");
		playerNameFieldUI = instance.FindProperty ("playerNameFieldUI");
		yourScoreTextUI = instance.FindProperty ("yourScoreTextUI");
		bestScoreTextUI = instance.FindProperty ("bestScoreTextUI");
		gunIconImageUI = instance.FindProperty ("gunIconImageUI");
	}
	
	public override void OnInspectorGUI()
	{
		instance.Update ();
		
		GUILayout.Space(10f);
		EditorGUILayout.PropertyField(lifeGroup);
		
		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(lifeIconPrefab);
		
		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(scoreTextUI);

		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(highScoreTextUI);

		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(readyTextUI);

		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(stageTextUI);

		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(gameOverImageUI);

		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(gameOverAnimator);

		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(playerNameFieldUI);

		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(yourScoreTextUI);

		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(bestScoreTextUI);

		GUILayout.Space(5f);
		EditorGUILayout.PropertyField(gunIconImageUI);
		
		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}