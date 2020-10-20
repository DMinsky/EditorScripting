using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor( typeof( Relic ) )]
public class RelicEditor : Editor
{
    [DrawGizmo( GizmoType.Active | GizmoType.NonSelected | GizmoType.Pickable )]
    private static void DrawTypeGizmo( Relic relic, GizmoType gizmoType )
    {
        string iconPath = "Relics/" + relic.relicType + ".png";
        Gizmos.DrawIcon( relic.transform.position, iconPath );
    }

    [DrawGizmo( GizmoType.Active | GizmoType.NonSelected )]
    private static void DrawHPGizmo( Relic relic, GizmoType gizmoType )
    {
        string hpLabel = "HP: " + relic.currHP + "/" + relic.maxHP;
        Handles.Label(
            relic.transform.position + Vector3.up * 0.125f,
            hpLabel,
            GUI.skin.FindStyle("AssetLabel")            
        );
    }

    [DrawGizmo( GizmoType.NonSelected )]
    private static void DrawTriggerZone( Relic relic, GizmoType gizmoType )
    {
        BoxCollider collider = relic.GetComponent<BoxCollider>();
        Gizmos.color = Color.black;
        Gizmos.matrix = relic.transform.localToWorldMatrix;
        Gizmos.DrawWireCube( Vector3.zero, collider.size );
    }

}
