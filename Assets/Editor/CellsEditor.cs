/*using System;
using UnityEditor;
using UnityEngine;

namespace Editor {
    [CustomEditor(typeof(Cell))]
    public class CellsEditor : UnityEditor.Editor {
        private Cell _cell;
        private CellParameters _cellParameters;

        private void OnEnable() {
            _cell = (Cell)target;
        }

        public override void OnInspectorGUI() {
            if (_cell.CellParameters.Count > 0) {
                foreach (var cell in _cell.CellParameters) {
                    EditorGUILayout.BeginVertical("box");
                    EditorGUILayout.BeginHorizontal(Max);
                    _cellParameters = cell;
                    _cellParameters.cellImage = (Sprite)EditorGUILayout.ObjectField("", 
                        _cellParameters.cellImage, typeof(Sprite), false);
                    EditorGUILayout.EndHorizontal();
                    _cellParameters.cellName = EditorGUILayout.TextField("Cell Name", _cellParameters.cellName);
                    
                    EditorGUILayout.EndVertical();
                }
            }
            else {
                if (GUILayout.Button("Add Cell", GUILayout.Height(30))) _cell.CellParameters.Add(new CellParameters());
            }
        }
    }
}*/
