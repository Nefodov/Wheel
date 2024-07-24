using UnityEngine;
using UnityEditor;

namespace ValueObjects
{
    [CustomEditor(typeof(ValueObject<>), true)]
    [CanEditMultipleObjects]
    public class ValueObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUI.enabled = false;

            var value = (serializedObject.targetObject as ValueObjectBase).RawValue();

            switch (value)
            {
                case int intValue:
                    EditorGUILayout.IntField(intValue);
                    break;
                case float floatValue:
                    EditorGUILayout.FloatField(floatValue);
                    break;
                case string stringValue:
                    EditorGUILayout.LabelField(stringValue);
                    break;
                case bool boolValue:
                    EditorGUILayout.Toggle(boolValue);
                    break;
                case Object objectValue:
                    EditorGUILayout.ObjectField(objectValue, typeof(Object), true);
                    break;
            }

            GUI.enabled = true;
        }
    }
}
