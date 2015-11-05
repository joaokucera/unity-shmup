using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(EnemySpawner))]
public class EnemySpawnerEditor : BaseEditor 
{
	#region [ FIELDS ]
	
	private SerializedProperty enemyBigPool;
	private SerializedProperty enemyCargoPool;
	private SerializedProperty enemyTurnPool;
	private SerializedProperty enemyOrdinaryPool;
	private SerializedProperty enemyFlipPool;
	private SerializedProperty enemyRearPool;
	private SerializedProperty enemyAcrobaticPool;

	private SerializedProperty probabilityPercentages;

	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		enemyBigPool = instance.FindProperty ("enemyBigPool");
		enemyCargoPool = instance.FindProperty ("enemyCargoPool");
		enemyTurnPool = instance.FindProperty ("enemyTurnPool");
		enemyOrdinaryPool = instance.FindProperty ("enemyOrdinaryPool");
		enemyFlipPool = instance.FindProperty ("enemyFlipPool");
		enemyRearPool = instance.FindProperty ("enemyRearPool");
		enemyAcrobaticPool = instance.FindProperty ("enemyAcrobaticPool");

		probabilityPercentages = instance.FindProperty ("probabilityPercentages");
	}
	
	public override void OnInspectorGUI ()
	{
		instance.Update ();
		
		GUILayout.Space (10f);
		EditorGUILayout.LabelField("Enemy Pools", EditorStyles.boldLabel);
		EditorGUILayout.PropertyField(enemyBigPool);
		EditorGUILayout.PropertyField(enemyCargoPool);
		EditorGUILayout.PropertyField(enemyTurnPool);
		EditorGUILayout.PropertyField(enemyOrdinaryPool);
		EditorGUILayout.PropertyField(enemyFlipPool);
		EditorGUILayout.PropertyField(enemyRearPool);
		EditorGUILayout.PropertyField(enemyAcrobaticPool);

		GUILayout.Space (10f);
		EditorGUILayout.LabelField("Enemies Probability Percentages", EditorStyles.boldLabel);

		SerializedProperty[] elements = new SerializedProperty[probabilityPercentages.arraySize];
		for (int i = 0; i < elements.Length; i++) 
		{
			elements[i] = probabilityPercentages.GetArrayElementAtIndex(i);
		}

		GUILayout.Space (5f);
		elements[0].intValue = 100 - elements[1].intValue - elements[2].intValue - elements[3].intValue - elements[4].intValue - elements[5].intValue - elements[6].intValue;
		elements[0].intValue = Mathf.Clamp (elements[0].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[0], 0, 100, "Acrobatic");
		if (!elements[0].hasMultipleDifferentValues)
		{
			ProgressBar (elements[0].intValue / 100f, "Acrobatic Probability Percentage (%)");
		}

		GUILayout.Space (-7.5f);
		elements[1].intValue = 100 - elements[0].intValue - elements[2].intValue - elements[3].intValue - elements[4].intValue - elements[5].intValue - elements[6].intValue;
		elements[1].intValue = Mathf.Clamp (elements[1].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[1], 0, 100, "Big");
		if (!elements[1].hasMultipleDifferentValues)
		{
			ProgressBar (elements[1].intValue / 100f, "Big Probability Percentage (%)");
		}

		GUILayout.Space (-7.5f);
		elements[2].intValue = 100 - elements[0].intValue - elements[1].intValue - elements[3].intValue - elements[4].intValue - elements[5].intValue - elements[6].intValue;
		elements[2].intValue = Mathf.Clamp (elements[2].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[2], 0, 100, "Cargo");
		if (!elements[2].hasMultipleDifferentValues)
		{
			ProgressBar (elements[2].intValue / 100f, "Cargo Probability Percentage (%)");
		}

		GUILayout.Space (-7.5f);
		elements[3].intValue = 100 - elements[0].intValue - elements[1].intValue - elements[2].intValue - elements[4].intValue - elements[5].intValue - elements[6].intValue;
		elements[3].intValue = Mathf.Clamp (elements[3].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[3], 0, 100, "Flip");
		if (!elements[1].hasMultipleDifferentValues)
		{
			ProgressBar (elements[3].intValue / 100f, "Flip Probability Percentage (%)");
		}

		GUILayout.Space (-7.5f);
		elements[4].intValue = 100 - elements[0].intValue - elements[1].intValue - elements[2].intValue - elements[3].intValue - elements[5].intValue - elements[6].intValue;
		elements[4].intValue = Mathf.Clamp (elements[4].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[4], 0, 100, "Ordinary");
		if (!elements[4].hasMultipleDifferentValues)
		{
			ProgressBar (elements[4].intValue / 100f, "Ordinary Probability Percentage (%)");
		}

		GUILayout.Space (-7.5f);
		elements[5].intValue = 100 - elements[0].intValue - elements[1].intValue - elements[2].intValue - elements[3].intValue - elements[4].intValue - elements[6].intValue;
		elements[5].intValue = Mathf.Clamp (elements[5].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[5], 0, 100, "Rear");
		if (!elements[5].hasMultipleDifferentValues)
		{
			ProgressBar (elements[5].intValue / 100f, "Rear Probability Percentage (%)");
		}

		GUILayout.Space (-7.5f);
		elements[6].intValue = 100 - elements[0].intValue - elements[1].intValue - elements[2].intValue - elements[3].intValue - elements[4].intValue - elements[5].intValue;
		elements[6].intValue = Mathf.Clamp (elements[6].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[6], 0, 100, "Turn");
		if (!elements[6].hasMultipleDifferentValues)
		{
			ProgressBar (elements[6].intValue / 100f, "Turn Probability Percentage (%)");
		}

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}