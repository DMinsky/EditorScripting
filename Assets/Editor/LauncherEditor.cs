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

    [DrawGizmo(GizmoType.Selected | GizmoType.Pickable)]
    static void DrawGizmosSelected(Launcher launcher, GizmoType gizmoType)
    {
        var offsetPosition = launcher.transform.TransformPoint(launcher.offset);
        Handles.DrawDottedLine(launcher.transform.position, offsetPosition, 3);
        Handles.Label(offsetPosition, "Offset");
        if (launcher.projectile != null) {
            var endPosition = offsetPosition + (
                launcher.transform.forward * launcher.velocity / launcher.projectile.mass
            );
            using(new Handles.DrawingScope(Color.yellow)) {
                Handles.DrawDottedLine(offsetPosition, endPosition, 1);
                Gizmos.DrawWireSphere(endPosition, 0.125f);
                Handles.Label(endPosition, "Estimated Position");
            }
        }
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
            launcher.transform.TransformPoint(launcher.offset)
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
