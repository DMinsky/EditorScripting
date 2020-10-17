using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SomeScript))]
public class SomeScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {        
        base.OnInspectorGUI();
        EditorGUILayout.HelpBox("This is a HelpBox", MessageType.Info);
        // DrawDefaultInspector();
    }
}
