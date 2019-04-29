using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RaycastTargetEditor : BaseEditor<UIRaycastTarget>
{
	SerializedProperty m_MyProperty;

	private void OnEnable()
	{
		m_MyProperty = FindProperty(x => x.raycastTarget);
	}

	public override void OnInspectorGUI()
	{
		EditorGUILayout.PropertyField(m_MyProperty);
	}
}
