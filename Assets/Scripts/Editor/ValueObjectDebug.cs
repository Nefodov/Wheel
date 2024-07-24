using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ValueObjects
{

	public class ValueObjectDebug : EditorWindow
	{
		[MenuItem("Tools/ValueObjectDebug")]
		private static void OpenWindow()
		{
			ValueObjectDebug window = GetWindow<ValueObjectDebug>();
			window.titleContent = new GUIContent("ValueObjects");
		}

		public ValueObjectBase targetObject;

		private void OnGUI()
		{
			ScriptableObject target = this;
			SerializedObject so = new SerializedObject(target);

			var targetObject_prop = so.FindProperty("targetObject");

			EditorGUILayout.PropertyField(targetObject_prop,true);
			so.ApplyModifiedProperties();

			if (targetObject == null)
				return;

			EditorGUILayout.LabelField(targetObject.RawValue()?.ToString());

			if (GUILayout.Button("AddListener"))
			{
				if (targetObject is ActionVoidObject)
				{
					(targetObject as ActionVoidObject).AddListener(() => Debug.Log(targetObject.name));
				}
				if (targetObject is ActionIntObject)
				{
					(targetObject as ActionIntObject).AddListener((x) => Debug.LogFormat("{0}\t{1}", targetObject.name, x));
				}
				if (targetObject is ActionFloatObject)
				{
					(targetObject as ActionFloatObject).AddListener((x) => Debug.LogFormat("{0}\t{1}", targetObject.name, x));
				}
			}
		}
	}
}
