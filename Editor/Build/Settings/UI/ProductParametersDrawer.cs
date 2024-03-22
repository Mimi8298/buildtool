using System;
using UnityEditor;
using UnityEngine;

namespace SuperUnityBuild.BuildTool
{
    [CustomPropertyDrawer(typeof(ProductParameters))]
    public class ProductParametersDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, GUIContent.none, property);

            EditorGUILayout.BeginHorizontal();

            bool show = property.isExpanded;
            UnityBuildGUIUtility.DropdownHeader("Product Parameters", ref show, false, GUILayout.ExpandWidth(true));
            property.isExpanded = show;

            UnityBuildGUIUtility.HelpButton("Parameter-Details#product-parameters");
            EditorGUILayout.EndHorizontal();

            if (show)
            {
                EditorGUILayout.BeginVertical(UnityBuildGUIUtility.dropdownContentStyle);

                // Temporarily override GUI label width size
                float currentLabelWidth = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = 200;

                EditorGUILayout.PropertyField(property.FindPropertyRelative("awsRegion"));
                EditorGUILayout.PropertyField(property.FindPropertyRelative("awsBuildCounterFunctionUrl"));
                EditorGUILayout.PropertyField(property.FindPropertyRelative("awsBuildVersionFunctionUrl"));

                property.serializedObject.ApplyModifiedProperties();

                EditorGUILayout.EndVertical();

                // Reset GUI label width size
                EditorGUIUtility.labelWidth = currentLabelWidth;
            }

            EditorGUI.EndProperty();
        }
    }
}
