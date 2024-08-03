using Code.Infrastructure;
using Code.Infrastructure.LevelConfigHandling;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(LevelConfigWriter))]
    public class LevelConfigWriterEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            LevelConfigWriter levelConfigWriter = (LevelConfigWriter)target;

            if (GUILayout.Button("WriteToJson"))
            {
                levelConfigWriter.Write();
            }
        }
    }
}