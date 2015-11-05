using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameOverControl))]
public class GameOverControlEditor : BaseEditor 
{
	#region [ FIELDS ]
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
	}
	
	public override void OnInspectorGUI()
	{
		instance.Update ();

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}