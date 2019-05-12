using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomPropertyDrawer(typeof(ExpandedAttribute),true)]
public class ExpandedDrawer : PropertyDrawer
{
	ExpandedAttribute Target
	{
		get
		{
			return attribute as ExpandedAttribute;
		}
	}

	private float m_verticalSpacing = 4f;
	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		if (property.isExpanded && property.objectReferenceValue != null)
		{
			SerializedObject objectSerialized = new SerializedObject(property.objectReferenceValue);
			SerializedProperty prop = objectSerialized.GetIterator();
			prop.Next(true);
			float h = m_verticalSpacing;
			while (prop.NextVisible(false))
			{
				h+= EditorGUI.GetPropertyHeight(prop);
				h += m_verticalSpacing;
			}
			return h;
		}
		return EditorGUI.GetPropertyHeight(property);
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.ObjectField(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), property, (property.objectReferenceValue && Target.hideName)? GUIContent.none : label);
		if (property.objectReferenceValue != null)
		{
			property.isExpanded = EditorGUI.Foldout(new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight), property.isExpanded, GUIContent.none);
			if (property.isExpanded)
			{
				SerializedObject objectSerialized = new SerializedObject(property.objectReferenceValue);
				SerializedProperty prop = objectSerialized.GetIterator();
				prop.NextVisible(true);
				float h = m_verticalSpacing;
				h += EditorGUIUtility.singleLineHeight;
				while (prop.NextVisible(false))
				{
					EditorGUI.PropertyField(new Rect(position.x + 10, position.y + h, position.width - 10, EditorGUIUtility.singleLineHeight), prop, true);
					h += EditorGUI.GetPropertyHeight(prop);
					h += m_verticalSpacing;
					prop.serializedObject.ApplyModifiedProperties();
				}
				objectSerialized.ApplyModifiedProperties();
			}
		}
		property.serializedObject.ApplyModifiedProperties();
	}
}
