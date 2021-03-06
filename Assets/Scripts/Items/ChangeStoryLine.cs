﻿using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DokiVnMaker.MyEditor.Items
{
    [Serializable]
    public class ChangeStoryLine : NodeBase
    {
        public string Name;
        [NonSerialized]
        public int Index;

        public ChangeStoryLine()
        {
            ActionType = ActionTypes.ChangeStoryLine;
        }

        public override void Draw()
        {
            GUILayout.BeginArea(myRect, Title, Style);
            GUILayout.Space(5);
            GUILayout.BeginHorizontal();
            GUILayout.Space(SpacePixel);
            GUILayout.FlexibleSpace();
            GUILayout.BeginVertical();
            GUILayout.Space(SpacePixel);

            //find all story line in main game
            GameObject game = GameObject.FindGameObjectWithTag("dokidoki_vn_game");
            var list = game.GetComponentsInChildren<StoryLine>().ToList();

            //set story line index if initialize request
            if (Initialize)
            {
                //find origin object
                var origin = list.Where(s => s.name == Name).FirstOrDefault();

                if (origin != null)
                {
                    //set index
                    Index = list.IndexOf(origin);
                }
                Initialize = false;
            }

            //get all story lines names
            var nameList = list.Select(s => s.gameObject.name).ToArray();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Story line", WhiteTxtStyle, GUILayout.Width(LabelWidth));
            Index = EditorGUILayout.Popup(Index, nameList);
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
            GUILayout.Space(SpacePixel);
            GUILayout.EndHorizontal();
            GUILayout.EndArea();

            InPoint.Draw();
            OutPoint.Draw();

            base.Draw();
        }

        public override NodeBase Clone(Vector2 pos, int newId)
        {
            var clone = new ChangeStoryLine()
            {
                Initialize = true,
                Name = Name,
            };

            clone.Init(pos, myRect.size, Style, SelectedNodeStyle, InPoint.Style,
                OutPoint.Style, InPoint.OnClickConnectionPoint, OutPoint.OnClickConnectionPoint,
                OnCopyNode, OnRemoveNode, newId);

            return clone;
        }
    }
}