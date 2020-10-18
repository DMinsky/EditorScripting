using System.Collections;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectBuilderScript))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ObjectBuilderScript myScript = (ObjectBuilderScript) target;
        if (GUILayout.Button("Build Object"))
        {
            myScript.BuildObject();
        }
    }
}