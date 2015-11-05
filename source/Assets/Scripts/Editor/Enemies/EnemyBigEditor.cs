using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyBig))]
public class EnemyBigEditor : BaseEnemyEditor 
{
	#region [ FIELDS ]
	
	private SerializedProperty waitingToMove;
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
		
		waitingToMove = instance.FindProperty ("waitingToMove");
	}
	
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();
		
		instance.Update ();
		
		GUILayout.Space (5f);
		EditorGUILayout.Slider(waitingToMove, 0f, 10f, "Waiting to move");
		EditorGUILayout.LabelField("(time to move again)", EditorStyles.miniLabel);

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}