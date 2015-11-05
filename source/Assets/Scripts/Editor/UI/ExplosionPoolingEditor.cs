using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ExplosionPooling))]
public class ExplosionPoolingEditor : GenericPoolingEditor 
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
		base.OnInspectorGUI ();

		instance.Update ();

		instance.ApplyModifiedProperties ();
	}
	
	#endregion
}