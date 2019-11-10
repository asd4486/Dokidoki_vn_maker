﻿using UnityEngine;
using UnityEditor;

namespace DokiVnMaker.Drawer
{
    [CustomPropertyDrawer(typeof(DialogueAnswerAttribute))]
    public class DialogueAnswerDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label.text = "";
            EditorGUI.PropertyField(position, property, label, true);
        }
    }
}