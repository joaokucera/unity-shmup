using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseItem))]
public abstract class BaseItemEditor : BaseEditor 
{
	#region [ FIELDS ]
	
	#endregion
	
	#region [ METHODS ]
	
	protected override void OnEnable ()
	{
		base.OnEnable ();
	}
	
	public override void OnInspectorGUI ()
	{
		instance.Update ();
		
		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}