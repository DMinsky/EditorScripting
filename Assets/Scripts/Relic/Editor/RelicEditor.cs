using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor( typeof( Relic ) )]
public class RelicEditor : Editor
{
    SerializedProperty currHP;
    SerializedProperty maxHP;

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

    void OnEnable()
    {
        Debug.Log( "OnEnable" );
        currHP = serializedObject.FindProperty( "currHP" );
        maxHP  = serializedObject.FindProperty( "maxHP" );
    }

    void OnDisable()
    {
        Debug.Log( "OnDisable" );
    }

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();        
        serializedObject.Update();
        if (!currHP.hasMultipleDifferentValues) {
            currHP.floatValue = EditorGUILayout.FloatField( "HP", currHP.floatValue );
        }
        maxHP.intValue = EditorGUILayout.IntField( "Max HP", maxHP.intValue );
        serializedObject.ApplyModifiedProperties();
    }

}
