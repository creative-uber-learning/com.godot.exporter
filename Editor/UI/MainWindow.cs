using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Godot
{
    public class MainWindow : EditorWindow 
    {
        [MenuItem("Godot/Export to Godot")]
        public static void ShowWindow() 
        {
            EditorWindow.GetWindow(typeof(MainWindow), false, "Export to Godot", true);
        }

        private void OnGUI() 
        {
            GUILayout.Label("Export Settings", EditorStyles.boldLabel);
            GUILayout.BeginHorizontal();
            godotProjectPath = EditorGUILayout.TextField("Target", godotProjectPath);
            if (GUILayout.Button("...", GUILayout.ExpandWidth(false)))
            {
                godotProjectPath = EditorUtility.OpenFilePanel("Select the Godot project to export to", "", "godot");
                Repaint();
            }
            GUILayout.EndHorizontal();

            GUILayout.Space(10);

            if (godotProjectPath == "")
                GUI.enabled = false;

            if (GUILayout.Button("Export", GUILayout.MaxWidth(100)))
            {
                var toTrim = "project.godot";
                var e = new Exporter(godotProjectPath.Remove(godotProjectPath.Length - toTrim.Length));
                e.Export();
            }
        }

        private string godotProjectPath = "";
    }
}
