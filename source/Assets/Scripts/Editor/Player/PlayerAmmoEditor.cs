using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerAmmo))]
public class PlayerAmmoEditor : BaseAmmoEditor 
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
		base.OnInspectorGUI ();
	}

	#endregion
}