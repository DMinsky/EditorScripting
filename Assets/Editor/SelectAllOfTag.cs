using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SelectAllOfTag : ScriptableWizard
{
    public string searchTag = "hui";

    [MenuItem("Tools/Select All of Tag")]
    static void SelectAllOfTagWizard()
    {
        ScriptableWizard.DisplayWizard<SelectAllOfTag>("Select all of tag", "Make Selection");
    }

    void OnWizardCreate()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(searchTag);
        Selection.objects = gameObjects;
    }

    void OnWizardUpdate()
    {
        helpString = "Please set the color of the light!";
    }
}
