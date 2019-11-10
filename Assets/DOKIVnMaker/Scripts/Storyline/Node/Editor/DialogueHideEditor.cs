﻿using UnityEngine;
using UnityEditor;
using XNodeEditor;

namespace DokiVnMaker.Story
{
    [CustomNodeEditor(typeof(DialogueHide))]
    public class DialogueHideEditor : StoryNodeEditorBase
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();
            DrawPorts();

            DrawDurationField();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("isWait"));

            serializedObject.ApplyModifiedProperties();
        }
    }
}