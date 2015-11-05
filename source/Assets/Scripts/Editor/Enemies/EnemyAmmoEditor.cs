using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyAmmo))]
public class EnemyAmmoEditor : BaseAmmoEditor {

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