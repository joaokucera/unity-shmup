using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(ItemSpawner))]
public class ItemSpawnerEditor : BaseEditor 
{
	#region [ FIELDS ]
	
	private SerializedProperty items;
	private SerializedProperty probabilityPercentages;

	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		items = instance.FindProperty ("items");
		probabilityPercentages = instance.FindProperty ("probabilityPercentages");
	}
	
	public override void OnInspectorGUI ()
	{
		instance.Update ();
		
		GUILayout.Space (10f);
		EditorGUILayout.PropertyField(items, true);
		EditorGUILayout.LabelField("(the items to spawn)", EditorStyles.miniLabel);

		GUILayout.Space (10f);
		EditorGUILayout.LabelField("Items Probability Percentages", EditorStyles.boldLabel);

		SerializedProperty[] elements = new SerializedProperty[probabilityPercentages.arraySize];
		for (int i = 0; i < elements.Length; i++) 
		{
			elements[i] = probabilityPercentages.GetArrayElementAtIndex(i);
		}

		GUILayout.Space (5f);
		elements[0].intValue = 100 - elements[1].intValue - elements[2].intValue - elements[3].intValue - elements[4].intValue - elements[5].intValue;
		elements[0].intValue = Mathf.Clamp (elements[0].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[0], 0, 100, "Nothing");
		if (!elements[0].hasMultipleDifferentValues)
		{
			ProgressBar (elements[0].intValue / 100f, "Nothing Probability Percentage (%)");
		}

		GUILayout.Space (-7.5f);
		elements[1].intValue = 100 - elements[0].intValue - elements[2].intValue - elements[3].intValue - elements[4].intValue - elements[5].intValue;
		elements[1].intValue = Mathf.Clamp (elements[1].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[1], 0, 100, "Gun Front");
		if (!elements[1].hasMultipleDifferentValues)
		{
			ProgressBar (elements[1].intValue / 100f, "Gun Front Probability Percentage (%)");
		}

		GUILayout.Space (-7.5f);
		elements[2].intValue = 100 - elements[0].intValue - elements[1].intValue - elements[3].intValue - elements[4].intValue - elements[5].intValue;
		elements[2].intValue = Mathf.Clamp (elements[2].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[2], 0, 100, "Gun Sides");
		if (!elements[2].hasMultipleDifferentValues)
		{
			ProgressBar (elements[2].intValue / 100f, "Gun Sides Probability Percentage (%)");
		}

		GUILayout.Space (-7.5f);
		elements[3].intValue = 100 - elements[0].intValue - elements[1].intValue - elements[2].intValue - elements[4].intValue - elements[5].intValue;
		elements[3].intValue = Mathf.Clamp (elements[3].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[3], 0, 100, "Gun Sides Back");
		if (!elements[1].hasMultipleDifferentValues)
		{
			ProgressBar (elements[3].intValue / 100f, "Gun Sides Back Probability Percentage (%)");
		}

		GUILayout.Space (-7.5f);
		elements[4].intValue = 100 - elements[0].intValue - elements[1].intValue - elements[2].intValue - elements[3].intValue - elements[5].intValue;
		elements[4].intValue = Mathf.Clamp (elements[4].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[4], 0, 100, "Gun Angle Sides Back");
		if (!elements[4].hasMultipleDifferentValues)
		{
			ProgressBar (elements[4].intValue / 100f, "Gun Angle Sides Back Probability Percentage (%)");
		}

		GUILayout.Space (-7.5f);
		elements[5].intValue = 100 - elements[0].intValue - elements[1].intValue - elements[2].intValue - elements[3].intValue - elements[4].intValue;
		elements[5].intValue = Mathf.Clamp (elements[5].intValue, 0, 100);
		EditorGUILayout.IntSlider(elements[5], 0, 100, "New Life");
		if (!elements[5].hasMultipleDifferentValues)
		{
			ProgressBar (elements[5].intValue / 100f, "New Life Probability Percentage (%)");
		}

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}