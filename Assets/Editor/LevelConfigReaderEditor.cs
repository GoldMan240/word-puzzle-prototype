using Code.Infrastructure.LevelConfigHandling;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(LevelConfigReader))]
    public class LevelConfigReaderEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            LevelConfigReader levelConfigReader = (LevelConfigReader)target;

            if (GUILayout.Button("ReadFromJson"))
            {
                levelConfigReader.Read();
            }
        }
    }
}