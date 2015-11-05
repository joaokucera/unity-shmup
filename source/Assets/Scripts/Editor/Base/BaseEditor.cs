using UnityEngine;
using UnityEditor;

public abstract class BaseEditor : Editor 
{
	#region [ FIELDS ]
	
	protected SerializedObject instance;

	#endregion
	
	#region [ METHODS ]
	
	protected virtual void OnEnable()
	{
		if(instance == null) instance = new SerializedObject(target);
	}

	/// <summary>
	/// Progresses the bar.
	/// </summary>
	/// <param name="value">Value.</param>
	/// <param name="label">Label.</param>
	protected void ProgressBar(float value, string label)
	{
		Rect rect = GUILayoutUtility.GetRect (18, 18, "TextField");
		EditorGUI.ProgressBar (rect, value, label);
		EditorGUILayout.Space ();
	}

	#endregion
}