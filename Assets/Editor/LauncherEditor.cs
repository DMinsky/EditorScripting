using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Launcher))]
public class LauncherEditor : Editor
{
    private Vector3 screenPos;
    private Rect rectResult;

    // public override void OnInspectorGUI()
    // {
    //     DrawDefaultInspector();
    //     EditorGUILayout.Vector3Field("Pos", screenPos);
    //     EditorGUILayout.RectField("Result", rectResult);
        
    // }

    [DrawGizmo(GizmoType.Selected | GizmoType.Pickable)]
    static void DrawGizmosSelected(Launcher launcher, GizmoType gizmoType)
    {
        var offsetPosition = launcher.transform.TransformPoint(launcher.offset);
        Handles.DrawDottedLine(launcher.transform.position, offsetPosition, 3);
        Handles.Label(offsetPosition, "Offset");
        if (launcher.projectile != null) {
            var positions = new List<Vector3>();
            var velocity = launcher.transform.forward * launcher.velocity / launcher.projectile.mass;
            var position = offsetPosition;
            var physicsStep = 0.1f;
            for (float i = 0f; i <= 1f; i += physicsStep)
            {
                positions.Add(position);
                position += velocity * physicsStep;
                velocity += Physics.gravity * physicsStep;
            }
            using(new Handles.DrawingScope(Color.yellow)) {
                Handles.DrawAAPolyLine(positions.ToArray());
                Gizmos.DrawWireSphere(positions[positions.Count-1], 0.125f);
                Handles.Label(positions[positions.Count-1], "Estimated Position");
            }
        }
    }

    void OnSceneGUI()
    {
        var launcher = target as Launcher;
        var transform = launcher.transform;

        using (var cc = new EditorGUI.ChangeCheckScope())
        {
            var newOffset = transform.InverseTransformPoint(
                Handles.PositionHandle(
                    transform.TransformPoint(launcher.offset),
                    transform.rotation
                )
            );
            if (cc.changed)
            {
                Undo.RecordObject(launcher, "Offset Change");
                launcher.offset = newOffset;
            }
        }


        // launcher.offset = transform.InverseTransformPoint(
        //     Handles.PositionHandle(
        //         transform.TransformPoint(launcher.offset),
        //         transform.rotation
        //     )
        // );

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
