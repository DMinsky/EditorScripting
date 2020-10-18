using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Launcher))]
public class LauncherEditor : Editor
{
    private Vector3 screenPos;
    private Rect rectResult;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        EditorGUILayout.Vector3Field("Pos", screenPos);
        EditorGUILayout.RectField("Result", rectResult);
        
    }

    void OnSceneGUI()
    {
        var launcher = target as Launcher;
        var transform = launcher.transform;
        launcher.offset = transform.InverseTransformPoint(
            Handles.PositionHandle(
                transform.TransformPoint(launcher.offset),
                transform.rotation
            )
        );

        Handles.BeginGUI();

        screenPos = Camera.current.WorldToScreenPoint(
            launcher.transform.position + launcher.offset
        );
        // 2 from retina screen?
        // SceneView.currentDrawingSceneView.position includes window header
        rectResult.xMin = screenPos.x / 2f;
        rectResult.yMin = (SceneView.currentDrawingSceneView.position.height * 2f - screenPos.y) / 2f;
        rectResult.width = 64;
        rectResult.height = 20;
        GUILayout.BeginArea(rectResult);
        using (new EditorGUI.DisabledGroupScope(!Application.isPlaying)) {
            if (GUILayout.Button("Fire")) {
                launcher.Fire();
            }
        }
        GUILayout.EndArea();
        Handles.EndGUI();
    }
}
