using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;

namespace Agava.AddressablesUtility.Editor
{
    public class SimulateLoadSpeedEditor : EditorWindow
    {
        private const int WindowMaxWidth = 500;
        private const int WindowMaxHeight = 100;
        private const int Mbit2Bit = 1024 * 1024;
        
        private readonly GUIContent _localLoadSpeedContent = new("Local Load Speed");
        private readonly GUIContent _remoteLoadSpeedContent = new("Remote Load Speed");
        private readonly GUIContent _mbsContent = new("Mbit/s");

        [MenuItem("Window/Asset Management/Addressables/Simulate Speed", priority = 2100)]
        private static void Open()
        {
            var window = GetWindow<SimulateLoadSpeedEditor>("Simulate Load Speed");
            window.maxSize = new Vector2(WindowMaxWidth, WindowMaxHeight);
            window.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            ProjectConfigData.LocalLoadSpeed = (long)(EditorGUILayout.FloatField(_localLoadSpeedContent, (float)ProjectConfigData.LocalLoadSpeed / Mbit2Bit) * Mbit2Bit);
            EditorGUILayout.LabelField(_mbsContent);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            ProjectConfigData.RemoteLoadSpeed = (long)(EditorGUILayout.FloatField(_remoteLoadSpeedContent, (float)ProjectConfigData.RemoteLoadSpeed / Mbit2Bit) * Mbit2Bit);
            EditorGUILayout.LabelField(_mbsContent);
            EditorGUILayout.EndHorizontal();
        }
    }
}
