using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class MenuItems : MonoBehaviour
{
    [MenuItem("Tools/Clear PlayerPrefs")]
    private static void NewMenuOption()
    {
        Debug.Log("Clear PlayerPrefs");
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("Assets/Load Selected Scene Additive")]
    private static void LoadAdditiveScene()
    {
        Debug.Log("Load additive");
        var selected = Selection.activeObject;
        // EditorApplication.OpenSceneAdditive(AssetDatabase.GetAssetPath(selected));
        EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(selected), OpenSceneMode.Additive);
    }

    [MenuItem("Assets/Load Selected Scene Additive", true)]
    private static bool LoadAdditiveSceneValidation()
    {
        return Selection.activeObject != null && Selection.activeObject.GetType() == typeof(SceneAsset);
    }

    [MenuItem("Assets/Create/Custom Configuration")]
    private static void CreateCustomConfiguration()
    {
        Debug.Log("Create Configuration");
    }

    [MenuItem("CONTEXT/ObjectBuilderScript/Mega Option")]
    private static void MegaRigidbodyOption()
    {
        Debug.Log(Selection.activeObject.name);
        var go = Selection.activeObject as GameObject;
        DestroyImmediate(go.GetComponent<ObjectBuilderScript>());
    }
}
